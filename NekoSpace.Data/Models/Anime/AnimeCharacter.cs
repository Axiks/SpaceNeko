using NekoSpaceList.Models.CharacterModels;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeCharacter
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
    }
}
