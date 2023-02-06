using NekoSpaceList.Models.CharacterModels;

namespace NekoSpaceList.Models.Manga
{
    public class MangaCharacterEntity
    {
        public Guid MangaId { get; set; }
        public MangaEntity Manga { set; get; }
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { set; get; }
    }
}
