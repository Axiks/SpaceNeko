using NekoSpace.Common.Enums.API;
using NekoSpace.Data.Contracts.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
namespace NekoSpace.API.Contracts.Models.Offer.Response.Basic
{
    [SwaggerSubType(typeof(TitleOfferResponse))]
    [SwaggerSubType(typeof(DescriptionOfferResponse))]
    [SwaggerSubType(typeof(PosterOfferResponse))]
    public abstract class BasicOfferResponse
    {
        [Required]
        public Guid MediaId { get; set; }
        [Required]
        public OfferType OfferType { get; set; }
        [Required]
        public Language Language { get; set; }
    }
}
