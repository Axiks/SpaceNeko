using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;

namespace NekoSpace.Data.Contracts.Entities.Anime
{
    public class AnimeSynopsisEntity : TextVariantSubItemEntity<AnimeEntity>
    {
        public Guid AnimeId { get => MediaId; set => MediaId = value; }
        public AnimeEntity Anime { get => Media; set => Media = value; }
    }
}
