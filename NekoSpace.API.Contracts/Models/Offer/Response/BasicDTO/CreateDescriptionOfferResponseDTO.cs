using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class CreateDescriptionOfferResponseDTO : CreateBasicOfferResponseDTO<DescriptionOfferResponse>
    {
        public CreateDescriptionOfferResponseDTO(DescriptionOfferResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
