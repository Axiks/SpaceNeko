using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;

namespace NekoSpace.Core.Services.AnimeService
{
    public class ProvidingTranslationOffertResultListDTO : AbstractResultDTO<List<OfferBasicResultDTO>>
    {
        public ProvidingTranslationOffertResultListDTO(List<OfferBasicResultDTO> result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
