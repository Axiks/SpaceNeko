using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
