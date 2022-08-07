namespace NekoSpaceList.Models.General
{
    public interface IMedia
    {
        public Guid Id { get; set; }
        public long MalId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
