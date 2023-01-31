using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class Character : Media
    {
        public ICollection<CharacterNames> Names { get; set; }
        public ICollection<CharacterAbout> Abouts { get; set; }
        public ICollection<CharacterPoster> Posters { get; set; }
        public ICollection<CharacterCover> Covers { get; set; }
        public ICollection<AnimeCharacter> Animes { get; set; }
        public ICollection<MangaCharacter> Mangas { get; set; }
        public AnotherCharacterService AnotherService { get; set; } // Воно містить посилання на зовнішні ресурси
    }

    public class CharacterNames : TextVariantSubItem<Character>
    {
        [Required]
        public Guid CharacterId { get => MediaId; set => MediaId = value; }
        public Character Character { get => Media; set => Media = value; }
    }

    public class CharacterAbout : TextVariantSubItem<Character>
    {
        [Required]
        public Guid CharacterId { get => MediaId; set => MediaId = value; }
        public Character Character { get => Media; set => Media = value; }
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

    public class AnotherCharacterService : AnotherService
    {
        public int? MyAnimeList { get; set; }
    }
}
