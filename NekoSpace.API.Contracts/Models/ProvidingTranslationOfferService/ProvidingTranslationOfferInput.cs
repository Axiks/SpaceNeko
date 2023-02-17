using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.ProvidingTranslationOfferService
{
    public class ProvidingTranslationOfferInput
    {
        public Guid AnimeId { get; set; }
        public string PropositionBody { get; set; }
        public Language Language { get; set; }
        public ItemFrom ItemFrom { get; set; }
    }
}
