using NekoSpace.Common.Enums.API;
using NekoSpace.Data.Contracts.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request
{
    [SwaggerSubType(typeof(TitleOfferRequest))]
    [SwaggerSubType(typeof(DescriptionOfferRequest))]
    [SwaggerSubType(typeof(PosterOfferRequest))]

    public abstract class OfferBasicRequest
    {
        [Required]
        public Guid MediaId { get; set; }
        [Required]
        public OfferType OfferType { get; set; }
        [Required]
        public Language Language { get; set; }
        public string? SourceName { get; set; }
        public string? SourceUrl { get; set; }
    }
}
