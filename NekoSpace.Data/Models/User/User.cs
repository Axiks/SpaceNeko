using Microsoft.AspNetCore.Identity;

namespace NekoSpace.Data.Models.User
{
    public class NekoUser : IdentityUser
    {
        public string? About { get; set; }
        public ICollection<UserFavoriteAnime> FavoriteAnimes { get; set; }
        public ICollection<UserRatingAnime> RatingAnimes { get; set; }
        public ICollection<UserAnimeViewingStatus> AnimeViewingStatuses { get; set; }
    }
}
