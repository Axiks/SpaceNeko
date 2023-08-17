using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class CreateBasicOfferResponseDTO<T> : AbstractResultDTO<T> where T : BasicOfferResponse
    {
        public CreateBasicOfferResponseDTO(T? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
