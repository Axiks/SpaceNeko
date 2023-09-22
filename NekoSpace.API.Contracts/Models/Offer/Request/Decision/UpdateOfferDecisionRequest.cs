using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.Offer.Request.Decision
{
    public class UpdateOfferDecisionRequest
    {
/*        public Guid offerId {  get; internal set; }
*/        [Required]
        public required bool isAccept { get; set; }
        public string notes { get; set; }
    }
}
