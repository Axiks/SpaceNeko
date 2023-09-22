using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class CreatePosterOfferResponseDTO : CreateBasicOfferResponseDTO<PosterOfferResponse>
    {
        public CreatePosterOfferResponseDTO(PosterOfferResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
