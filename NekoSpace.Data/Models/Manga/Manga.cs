using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class Manga : Media
    {
        public ICollection<MangaTitle> Titles { get; set; }
        public ICollection<MangaSynopsis> Synopsises { get; set; }
        public ICollection<MangaPoster> Posters { get; set; }
        public ICollection<MangaCover> Covers { get; set; }
        [Required]
        public int ChaptersCount { get; set; }
        public ICollection<MangaGenre> Genres { get; set; }
        public ICollection<MangaCharacter> Characters { get; set; }
        [Required]
        public Published Published { get; set; }
        public bool Publishing { get; set; }
        public MangaStatus ReadStatus { get; set; } // Where user Login
        public MangaType Type { get; set; }
        [Required]
        public int Volumes { get; set; }
        public AnotherMangaService AnotherService { get; set; }
    }

    public class MangaTitle : TextVariantSubItem<Manga>
    {
        [Required]
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public Manga Manga { get => Media; set => Media = value; }
    }

    public class MangaSynopsis : TextVariantSubItem<Manga>
    {
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public Manga Manga { get => Media; set => Media = value; }
    }

    public class MangaGenre
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public int GenreId { get; set; }
        public Genre Genre { set; get; }
    }

    public class Published : ITimePeriod
    {
        public Guid Id { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class MangaPoster
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public int PosterId { get; set; }
        public Image Poster { set; get; }
    }

    public class MangaCover
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public int CoverId { get; set; }
        public Image Cover { set; get; }
    }

    public class MangaCharacter
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
    }

    public class AnotherMangaService : AnotherService
    {
    }
}
