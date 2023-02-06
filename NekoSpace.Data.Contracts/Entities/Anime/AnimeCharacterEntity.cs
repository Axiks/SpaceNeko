using NekoSpaceList.Models.CharacterModels;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeCharacterEntity
    {
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { set; get; }
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { set; get; }
    }
}
