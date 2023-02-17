using NekoSpace.API.Contracts.Abstract.General;

namespace NekoSpace.Core.Services.AnimeService
{
    public class ProvidingTranslationOffertResponse : AbstractResponseModel<bool>
    {
        public ProvidingTranslationOffertResponse(bool result, string? error) : base(result, error)
        {
        }
    }
}
