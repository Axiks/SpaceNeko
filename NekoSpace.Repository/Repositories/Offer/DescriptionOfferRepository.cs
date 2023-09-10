using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.General.Media;
using NekoSpace.Repository.Contracts.Interfaces;
using NekoSpace.Repository.Repositories.Offer.Abstract;
using NekoSpaceList.Models.General;

namespace NekoSpace.Repository.Repositories.Offer
{
    public class DescriptionOfferRepository : OfferRepository<MediaSynopsisEntity>
    {
        public DescriptionOfferRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
