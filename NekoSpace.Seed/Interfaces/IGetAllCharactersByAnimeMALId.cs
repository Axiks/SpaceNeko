using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface IGetAllCharactersByAnimeMALId
    {
        public IEnumerable<RTO<Character>> GetAllCharactersByAnimeMALId(long MALId);
    }
}
