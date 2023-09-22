using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class UpdateOfferDecisionResponseDTO : AbstractResultDTO<BasicOfferResponse>
    {
        public UpdateOfferDecisionResponseDTO(BasicOfferResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
