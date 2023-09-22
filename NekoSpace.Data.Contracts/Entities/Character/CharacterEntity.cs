using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.Character;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.Manga;

namespace NekoSpaceList.Models.CharacterModels
{
    public class CharacterEntity : MediaEntity
    {
        public ICollection<CharacterNamesEntity> Names { get; set; }
        public ICollection<CharacterAboutEntity> Abouts { get; set; }
        //public ICollection<CharacterPosterEntity> Posters { get; set; }
        //public ICollection<CharacterCoverEntity> Covers { get; set; }
        public ICollection<AnimeCharacterEntity> Animes { get; set; }
        public ICollection<MangaCharacterEntity> Mangas { get; set; }
    }
}
