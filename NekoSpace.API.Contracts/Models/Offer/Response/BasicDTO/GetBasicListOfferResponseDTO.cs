using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO
{
    public class GetBasicListOfferResponseDTO<T> : AbstractResultDTO<BasicListOfferResult<T>> where T : BasicOfferResponse
    {
        public GetBasicListOfferResponseDTO(BasicListOfferResult<T>? result, ProblemDetails? error) : base(result, error)
        {
        }
    }

    public class BasicListOfferResult<T> where T : BasicOfferResponse
    {
        public int totalApplication {  get; set; }
        public int applicationAccepted { get; set; }
        public int applicationRejected { get; set; }
        public int applicationsArePending { get; set; }
        public List<T> results {  get; set; }
    }
}
