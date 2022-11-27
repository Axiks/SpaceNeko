using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface IGetAllAnimeByCharacterMALId
    {
        public Task<RTO<Anime>> GetAllAnimeByCharacterMALId(long MALId);
    }
}
