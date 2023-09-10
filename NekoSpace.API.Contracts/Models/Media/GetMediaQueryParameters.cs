using NekoSpace.API.Contracts.Models.Basic.Media;
using NekoSpace.Common.Enums.API;

namespace NekoSpace.API.Contracts.Models.Media
{
    public class GetMediaQueryParameters : MediaQueryParametersBasic
    {
        public List<MediaSort>? sort_by { get; set; }
    }
}
