using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Core.Contracts.Models.ProvidingTranslationOfferService
{
    public class ProvidingTranslationOffer
    {
        [Required]
        public string PropositionBody { get; set; }
        [Required]
        public Language Language { get; set; }
    }
}
