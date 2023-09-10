using NekoSpace.ElasticSearch;
using NekoSpace.Repository.Contracts.Interfaces;
using NekoSpaceList.Models.General;

namespace NekoSpace.Repository.Repositories.Offer.Abstract
{
    public abstract class ESOfferRepositoryProxy<D> : IOfferRepository<D> where D : RootVariantSubItemEntity
    {
        private OfferRepository<D> _offerRepository;

        protected ESOfferRepositoryProxy(OfferRepository<D> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public Task<D?> GetOffer(Guid offerId)
        {
            return _offerRepository.GetOffer(offerId);
        }

        public Task<D> CreateOffer(D offer)
        {
            var result = _offerRepository.CreateOffer(offer);
            AddOfferToES(offer);
            return result;
        }

        public void DeleteOffer(D offer)
        {
            _offerRepository.DeleteOffer(offer);
            DeleteOfferInES(offer);
        }

        public Task<D> UpdateOffer(D offer)
        {
            var result = _offerRepository.UpdateOffer(offer);
            UpdateOfferInES(offer);
            return result;
        }

        private protected abstract void AddOfferToES(D offer);
        private protected abstract void UpdateOfferInES(D offer);
        private protected abstract void DeleteOfferInES(D offer);
    }
}
