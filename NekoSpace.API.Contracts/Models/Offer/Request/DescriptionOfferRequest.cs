using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request
{
    public class DescriptionOfferRequest : OfferBasicRequest
    {
        [Required]
        public string Description { get; set; }
    }
}
