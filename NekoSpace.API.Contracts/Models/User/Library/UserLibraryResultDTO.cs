using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;

namespace NekoSpace.API.Contracts.Models.UserService.UserUpdates
{
    public class UserLibraryResult : AbstractResultDTO<UserLibraryResponse?>
    {
        public UserLibraryResult(UserLibraryResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }

    public class UserLibraryResponse
    {
        public List<UserAnimeRatingResponse> UserAnimeRatingResponses { get; set; } = new List<UserAnimeRatingResponse>();
        public List<UserAnimeViewingStatusResponse> UserAnimeViewingStatusResponses { get; set; } = new List<UserAnimeViewingStatusResponse>();
        public List<UserFavoriteAnimeResponse> UserFavoriteAnimeResponses { get; set; } = new List<UserFavoriteAnimeResponse>();

    }

    public class UserAnimeRatingResponse
    {
        public Guid AnimeId { get; set; }
        public float Score { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
    public class UserAnimeViewingStatusResponse
    {
        public Guid AnimeId { get; set; }
        public string Status { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

    }
    public class UserFavoriteAnimeResponse
    {
        public Guid AnimeId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
