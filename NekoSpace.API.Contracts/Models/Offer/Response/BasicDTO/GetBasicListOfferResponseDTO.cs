using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class GetBasicListOfferResponseDTO<T> : AbstractResultDTO<List<T>> where T : BasicOfferResponse
    {
        public GetBasicListOfferResponseDTO(List<T>? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
