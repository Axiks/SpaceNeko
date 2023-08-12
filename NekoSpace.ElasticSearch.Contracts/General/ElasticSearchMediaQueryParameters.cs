using NekoSpace.Common.Enums.API;

namespace NekoSpace.ElasticSearch.Contracts.General
{
    public class ElasticSearchMediaQueryParameters
    {
        public string? q { get; set; }
        public int limit { get; set; } = 40;
        public int offset { get; set; } = 0;
        public int? from_year_release { get; set; }
        public int? to_year_release { get; set; }
        public List<OfferType>? where_adapted { get; set; }
        public List<OfferType>? where_no_adapted { get; set; }
        public List<MediaSort>? sort_by { get; set; }
    }
}
