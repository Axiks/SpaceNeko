using NekoSpace.Data.Models.User;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

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

    public class AnimeTitle : TextVariantSubItem<Anime>
    {
        [Required]
        public Guid AnimeId { get => MediaId; set => MediaId = value; }
        public Anime Anime { get => Media; set => Media = value; }
    }

    public class AnimeSynopsis : TextVariantSubItem<Anime>
    {
        public Guid AnimeId { get => MediaId; set => MediaId = value; }
        public Anime Anime { get => Media; set => Media = value; }
    }

    public class Premier
    {
        public Guid Id { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public Sezon Sezon { get; set; }
    }

    public class AnimeGenre
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public int GenreId { get; set; }
        public Genre Genre { set; get; }
    }

    public class Aired : ITimePeriod
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class AnimePoster
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public int PosterId { get; set; }
        public Image Poster { set; get; }
    }

    public class AnimeCover
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public int CoverId { get; set; }
        public Image Cover { set; get; }
    }

    public class AnimeCharacter
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
    }

    public class AnotherAnimeService : AnotherService
    {
        private int malId;

        /*public AnotherAnimeService(int MalId)
        {
            malId = MalId;
        }*/

        public int? KitsuId { get; set; }
        public string? NotifyId { get; set; }
        public string? AnimePlanetId { get; set; }
        public int? AniSearchId { get; set; }
        public int? LivechartMeId { get; set; }
        public int? MyAnimeList { get; set; }
    }
}
