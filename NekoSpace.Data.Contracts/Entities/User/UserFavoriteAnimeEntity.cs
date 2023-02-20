using NekoSpaceList.Models.Anime;

namespace NekoSpace.Data.Models.User
{
    public class UserFavoriteAnimeEntity
    {
        public Guid Id;
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = new DateTimeOffset(DateTime.UtcNow);
    }
}
