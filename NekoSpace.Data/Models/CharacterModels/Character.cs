using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;

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
}
