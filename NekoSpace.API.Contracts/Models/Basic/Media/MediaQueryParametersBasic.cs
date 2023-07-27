using NekoSpace.Common.Enums.API;

namespace NekoSpace.API.Contracts.Models.Basic.Media
{
    public class MediaQueryParametersBasic : QueryParametersBasic
    {
        public int? from_year_release { get; set; }
        public int? to_year_release { get; set; }
        public List<AdaptationType>? where_adapted { get; set; }
        public List<AdaptationType>? where_no_adapted { get; set; }
    }
}
