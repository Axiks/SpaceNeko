using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request
{
    public class TitleOfferRequest : OfferBasicRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
