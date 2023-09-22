using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;

namespace NekoSpace.API.Contracts.Models.Offer.Response
{
    public class UpdateOfferResponseDTO : AbstractResultDTO<OfferBasicResultDTO>
    {
        public UpdateOfferResponseDTO(OfferBasicResultDTO? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
