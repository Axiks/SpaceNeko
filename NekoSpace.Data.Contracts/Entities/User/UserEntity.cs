using Microsoft.AspNetCore.Identity;
using NekoSpace.Data.Contracts.Entities.User.OAuth;

namespace NekoSpace.Data.Models.User
{
    public class UserEntity : IdentityUser
    {
        public RefreshToken RefreshToken { get; set; }
        public string? About { get; set; }
        public ICollection<UserFavoriteAnimeEntity> FavoriteAnimes { get; set; }
        public ICollection<UserRatingAnimeEntity> RatingAnimes { get; set; }
        public ICollection<UserAnimeViewingStatusEntity> AnimeViewingStatuses { get; set; }
    }
}
