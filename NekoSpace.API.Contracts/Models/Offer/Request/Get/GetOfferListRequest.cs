using NekoSpace.Common.Enums.API;
using NekoSpace.Repository.Contracts.Enums;

namespace NekoSpace.API.Contracts.Models.Offer.Request.Get
{
    public class GetOfferListRequest
    {
        public int limit { get; set; } = 40;
        public int offset { get; set; } = 0;
        public List<OfferType>? filterByOfferType { get; set; }
        public OfferSort? sortBy { get; set; }
    }
}
