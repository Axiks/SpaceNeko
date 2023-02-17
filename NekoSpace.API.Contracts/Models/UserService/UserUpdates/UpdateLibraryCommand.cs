using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.UserService.UserUpdates
{
    public class UpdateLibraryCommand
    {
        [Required]
        public Guid AnimeId { get; set; }
        public UserViewStatus? UserViewStatus { get; set; }
        [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Score { get; set; }
        public bool? IsFavorite { get; set; }
    }
}