using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;

namespace NekoSpace.Core.Services.AnimeService
{
    public class ProvidingTranslationOffertResultDTO : AbstractResultDTO<OfferBasicResultDTO>
    {
        public ProvidingTranslationOffertResultDTO(OfferBasicResultDTO? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
