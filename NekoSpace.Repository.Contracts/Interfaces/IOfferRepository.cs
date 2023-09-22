using NekoSpaceList.Models.General;

namespace NekoSpace.Repository.Contracts.Interfaces
{
    public interface IOfferRepository<D> where D : RootVariantSubItemEntity
    {
        public Task<D?> GetOffer(Guid offerId);
        public Task<D> CreateOffer(D offer);
        public Task<D> UpdateOffer(D offer);
        public void DeleteOffer(D offer);
    }
}
