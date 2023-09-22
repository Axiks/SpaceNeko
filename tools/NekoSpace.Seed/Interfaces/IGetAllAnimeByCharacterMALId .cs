using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface IGetAllAnimeByCharacterMALId
    {
        public Task<RTO<AnimeEntity>> GetAllAnimeByCharacterMALId(long MALId);
    }
}
