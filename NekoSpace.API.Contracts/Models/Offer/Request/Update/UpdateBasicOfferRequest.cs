using NekoSpace.API.Contracts.Models.Offer.Request.Decision;
using NekoSpace.Common.Enums.API;
using NekoSpace.Data.Contracts.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.Offer.Request.Update
{

    [SwaggerSubType(typeof(UpdateTitleOfferRequest))]
    [SwaggerSubType(typeof(UpdateDescriptionOfferRequest))]
    public abstract class UpdateBasicOfferRequest
    {
        [Required]
        public Guid OfferId { get; set; }
        public OfferType OfferType { get; set; }
        public Language Language { get; set; }
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
        public bool IsHidden { get; set; } = false;
        public string? SourceName { get; set; }
        public string? SourceUrl { get; set; }

        //Temp?
        public UpdateOfferDecisionRequest? Decision { get; set; }
    }
}
