using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;

namespace NekoSpace.Data.Contracts.Entities.Manga
{
    public class MangaSynopsisEntity : TextVariantSubItemEntity<MangaEntity>
    {
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public MangaEntity Manga { get => Media; set => Media = value; }
    }
}
