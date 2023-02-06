using Microsoft.AspNetCore.Identity;

namespace NekoSpace.Data.Models.User
{
    public class UserEntity : IdentityUser
    {
        public string? About { get; set; }
        public ICollection<UserFavoriteAnimeEntity> FavoriteAnimes { get; set; }
        public ICollection<UserRatingAnimeEntity> RatingAnimes { get; set; }
        public ICollection<UserAnimeViewingStatusEntity> AnimeViewingStatuses { get; set; }
    }
}
