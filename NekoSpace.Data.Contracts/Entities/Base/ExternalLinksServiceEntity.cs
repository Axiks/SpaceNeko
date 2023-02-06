namespace NekoSpaceList.Models.General
{
    public abstract class ExternalLinksServiceEntity
    {
        public Guid Id { get; set; }
        public int? AnimeDBId { get; set; }
        public int? AnilistId { get; set; }
    }
}
