using Microsoft.EntityFrameworkCore;
using NekoSpace.Data;
using NekoSpace.Repository.Contracts.Interfaces;
using NekoSpaceList.Models.General;

namespace NekoSpace.Repository.Repositories.Offer.Abstract
{
    public class OfferRepository<D> : IOfferRepository<D> where D : RootVariantSubItemEntity
    {
        private ApplicationDbContext _dbContext;
        private DbSet<D> _propositionDbSet;

        public OfferRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
            _propositionDbSet = _dbContext.Set<D>();
        }

        public Task<D?> GetOffer(Guid offerId)
        {
            // Достатньо взяти з бази даних
            var offer = _propositionDbSet.FirstOrDefaultAsync(x => x.Id == offerId);
            return offer;
        }
        public async Task<D> CreateOffer(D offer)
        {
            CreateOfferInDb(offer);
            return offer;
        }
        public async Task<D> UpdateOffer(D offer)
        {
            UpdateOfferInDb(offer);
            return offer;
        }
        public async void DeleteOffer(D offer)
        {
            DeleteOfferInDb(offer);
        }

        private protected async void CreateOfferInDb(D offer)
        {
            _dbContext.Add(offer);
            _dbContext.SaveChangesAsync();
        }
        private protected async void UpdateOfferInDb(D offer)
        {
            _dbContext.Update(offer);
            _dbContext.SaveChangesAsync();
        }
        private protected async void DeleteOfferInDb(D offer)
        {
            _dbContext.Remove(offer);
            _dbContext.SaveChangesAsync();
        }

    }
}
