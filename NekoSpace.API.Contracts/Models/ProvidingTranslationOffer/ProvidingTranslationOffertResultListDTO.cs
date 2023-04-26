using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;

namespace NekoSpace.Core.Services.AnimeService
{
    public class ProvidingTranslationOffertResultListDTO : AbstractResultModel<List<OfferBasicResultDTO>>
    {
        public ProvidingTranslationOffertResultListDTO(List<OfferBasicResultDTO> result, ErrorResultDTO? error) : base(result, error)
        {
        }
    }
}
