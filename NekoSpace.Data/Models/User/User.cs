using Microsoft.AspNetCore.Identity;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Models.User
{
    public class NekoUser : IdentityUser
    {
        public string? About { get; set; }
        public ICollection<UserFavoriteAnime> FavoriteAnimes { get; set; }
        public ICollection<UserRatingAnime> RatingAnimes { get; set; }
        public ICollection<UserAnimeViewingStatus> AnimeViewingStatuses { get; set; }
    }

    public class UserFavoriteAnime
    {
        public Guid Id;
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public string UserId { get; set; }
        public NekoUser User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class UserRatingAnime
    {
        [Required]
        public float RatingValue { get; set; }
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public string UserId { get; set; }
        public NekoUser User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class UserAnimeViewingStatus
    {
        [Required]
        public UserViewStatus Status { get; set; }
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public string UserId { get; set; }
        public NekoUser User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
