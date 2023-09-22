using NekoSpace.Data.Contracts.Enums;
using NekoSpaceList.Models.Anime;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Models.User
{
    public class UserAnimeViewingStatusEntity
    {
        [Required]
        public UserViewStatus Status { get; set; }
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = new DateTimeOffset(DateTime.UtcNow);
        public DateTimeOffset UpdatedAt { get; set; } = new DateTimeOffset(DateTime.UtcNow);
    }
}
