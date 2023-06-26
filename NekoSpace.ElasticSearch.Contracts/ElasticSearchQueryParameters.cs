namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchQueryParameters
    {
        public string? q { get; set; }
        public int limit { get; set; } = 40;
        public int offset { get; set; } = 0;
    }
}
