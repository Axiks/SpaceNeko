using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Account;

namespace NekoSpace.API.Contracts.Models.Offer.Response
{
    public class DeleteOfferResponseDTO : AbstractResultDTO<DeleteOfferResponse>
    {
        public DeleteOfferResponseDTO(DeleteOfferResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }

    public class DeleteOfferResponse
    {
        public bool Success { get; set; }
    }

}
