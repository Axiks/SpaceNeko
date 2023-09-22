using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.Offer.Response.Basic
{
    public class PosterOfferResponse : BasicOfferResponse
    {
        [Required]
        public string MediumSrc { get; set; }
    }
}
