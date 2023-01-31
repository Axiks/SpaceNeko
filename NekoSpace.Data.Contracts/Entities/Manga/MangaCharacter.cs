using NekoSpaceList.Models.CharacterModels;

namespace NekoSpaceList.Models.Manga
{
    public class MangaCharacter
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
    }
}
