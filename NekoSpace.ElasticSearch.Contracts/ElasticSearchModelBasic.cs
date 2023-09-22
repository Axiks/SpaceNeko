namespace NekoSpace.ElasticSearch.Contracts
{
    public class ElasticSearchModelBasic
    {
        public Guid DBId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}