using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.Offer.Request.Update
{
    public class UpdateTitleOfferRequest : UpdateBasicOfferRequest
    {
        public string Name { get; set; }
    }
}
