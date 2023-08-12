using NekoSpace.Common.Enums;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.General;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Data.Models.User;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.Anime;

public class AnimeEntity : MediaEntity
{
/*    public ICollection<AnimeTitleEntity> Titles { get; set; }
    public ICollection<AnimeSynopsisEntity>? Synopsises { get; set; }*/
    public AnimeType? Type { get; set; }
    public AiringStatus? AiringStatus { get; set; }
    public AgeRating? AgeRating { get; set; }
    public Source? Source { get; set; }
    public ICollection<AnimeGenreEntity>? Genres { get; set; }
    public ICollection<AnimeCharacterEntity>? Characters { get; set; }
    [Required]
    public int? NumEpisodes { get; set; }
    public int? EpisodesDurationSeconds { get; set; }
    public PremierEntity? Premier { get; set; }
    public AiredEntity? Aired { get; set; }
    public ICollection<UserFavoriteAnimeEntity> FavoriteInUsers { get; set; }
    public ICollection<UserRatingAnimeEntity> RatingInUsers { get; set; }
    public ICollection<UserAnimeViewingStatusEntity> ViewingStatusInUsers { get; set; }
}
