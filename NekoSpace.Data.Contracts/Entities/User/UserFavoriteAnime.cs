using NekoSpaceList.Models.Anime;

namespace NekoSpace.Data.Models.User
{
    public class UserFavoriteAnime
    {
        public Guid Id;
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
