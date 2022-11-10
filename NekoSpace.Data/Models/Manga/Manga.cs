using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class Manga : IMedia
    {
        public Guid Id { get; set; }
        public ICollection<MangaTitle> Titles { get; set; }
        public ICollection<MangaSynopsis> Synopsises { get; set; }
        public ICollection<MangaPoster> Posters { get; set; }
        public ICollection<MangaCover> Covers { get; set; }
        public int ChaptersCount { get; set; }
        public ICollection<MangaGenre> Genres { get; set; }
        public ICollection<MangaCharacter> Characters { get; set; }
        public Published Published { get; set; }
        public bool Publishing { get; set; }
        public MangaStatus ReadStatus { get; set; } // Where user Login
        public MangaType Type { get; set; }
        public int Volumes { get; set; }
        public AnotherMangaService AnotherService { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class MangaTitle : ITextVariantSubItem<Manga>
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Languages Language { get; set; }
        public ItemFrom From { get; set; }
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
        public Guid MediaId { get; set; }
        public Manga Media { get; set; }
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public Manga Manga { get => Media; set => Media = value; }
        public bool? IsAcceptProposal { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class MangaSynopsis : ITextVariantSubItem<Manga>
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Languages Language { get; set; }
        public ItemFrom From { get; set; }
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
        public Guid MediaId { get; set; }
        public Manga Media { get; set; }
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public Manga Manga { get => Media; set => Media = value; }
        public bool? IsAcceptProposal { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
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
