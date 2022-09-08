using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class Character : IMedia
    {
        public Guid Id { get; set; }
        public long MalId { get; set; }
        public ICollection<CharacterNames> Names { get; set; }
        public ICollection<CharacterAbout> Abouts { get; set; }
        public ICollection<CharacterPoster> Posters { get; set; }
        public ICollection<CharacterCover> Covers { get; set; }
        public ICollection<AnimeCharacter> Animes { get; set; }
        public ICollection<MangaCharacter> Mangas { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class CharacterNames : ITextVariantSubItem<Character>
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Languages Language { get; set; }
        public ItemFrom From { get; set; }
        public bool IsOriginal { get; set; }
        public bool IsMain { get; set; }
        public Guid MediaId { get; set; }
        public Character Media { get; set; }
        public Guid CharacterId { get => MediaId; set => MediaId = value; }
        public Character Character { get => Media; set => Media = value; }
        public bool? IsAcceptProposal { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class CharacterAbout : ITextVariantSubItem<Character>
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Languages Language { get; set; }
        public ItemFrom From { get; set; }
        public bool IsOriginal { get; set; }
        public bool IsMain { get; set; }
        public Guid MediaId { get; set; }
        public Character Media { get; set; }
        public Guid CharacterId { get => MediaId; set => MediaId = value; }
        public Character Character { get => Media; set => Media = value; }
        public bool? IsAcceptProposal { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class CharacterPoster
    {
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
        public int PosterId { get; set; }
        public Image Poster { set; get; }
    }

    public class CharacterCover
    {
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
        public int CoverId { get; set; }
        public Image Cover { set; get; }
    }
}
