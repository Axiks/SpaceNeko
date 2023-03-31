using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;

namespace NekoSpace.Core.Services.AnimeService
{
    public class ProvidingTranslationOffertResultDTO : AbstractResultModel<OfferBasicResultDTO>
    {
        public ProvidingTranslationOffertResultDTO(OfferBasicResultDTO? result, string? error) : base(result, error)
        {
        }
    }
}
