using NekoSpace.Data.Contracts.Entities.Enumerations;
using NekoSpace.Data.Contracts.Entities.General.Abstract;
using NekoSpace.Data.Models.User;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.Anime
{
    public class Anime : Media
    {
        public ICollection<AnimeTitle> Titles { get; set; }
        public ICollection<AnimeSynopsis>? Synopsises { get; set; }
        public AnimeType Type { get; set; }
        public AiringStatus AiringStatus { get; set; }
        public AgeRating AgeRating { get; set; }
        public Source Source { get; set; } = Source.Undefined;
        public ICollection<AnimeGenre>? Genres { get; set; }
        public ICollection<AnimeCharacter>? Characters { get; set; }
        [Required]
        public int? NumEpisodes { get; set; }
        public int? EpisodesDurationSeconds { get; set; }
        public Premier? Premier { get; set; }
        public Aired? Aired { get; set; }
        public ICollection<AnimePoster>? Posters { get; set; }
        public ICollection<AnimeCover>? Covers { get; set; }
        public AnotherAnimeService AnotherService { get; set; }
        public ICollection<UserFavoriteAnime> FavoriteInUsers { get; set; }
        public ICollection<UserRatingAnime> RatingInUsers { get; set; }
        public ICollection<UserAnimeViewingStatus> ViewingStatusInUsers { get; set; }
    }
}
