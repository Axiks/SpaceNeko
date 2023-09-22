using NekoSpace.Common.Enums.API;
using NekoSpace.Data.Contracts.Enums;
using Swashbuckle.AspNetCore.Annotations;
namespace NekoSpace.API.Contracts.Models.Offer.Response.Basic
{
    [SwaggerSubType(typeof(TitleOfferResponse))]
    [SwaggerSubType(typeof(DescriptionOfferResponse))]
    [SwaggerSubType(typeof(PosterOfferResponse))]
    public abstract class BasicOfferResponse
    {
        public required Guid OfferId { get; set; }
        public Guid MediaId { get; set; }
        public OfferType OfferType { get; set; }
        public Language Language { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        //Test
        public bool? IsAcceptProposal { get; set; }
        public Guid? CreatorUserId { get; set; }
        public Guid? AcceptOfferUserId { get; set; }
        public string? Notes { get; set; }
    }
}
