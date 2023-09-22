using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class CreateTitleOfferResponseDTO : CreateBasicOfferResponseDTO<TitleOfferResponse>
    {
        public CreateTitleOfferResponseDTO(TitleOfferResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
