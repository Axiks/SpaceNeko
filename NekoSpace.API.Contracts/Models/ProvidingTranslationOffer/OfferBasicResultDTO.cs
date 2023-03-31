using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.ProvidingTranslationOffer
{
    public class OfferBasicResultDTO
    {
        public Guid Id { get; set; }
        public Guid AnimeId { get; set; }
        public string Body { get; set; }
        public Language Language { get; set; }
        public ItemFrom From { get; set; }
        public bool IsMain { get; set; }
        public bool? IsAcceptProposal { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
