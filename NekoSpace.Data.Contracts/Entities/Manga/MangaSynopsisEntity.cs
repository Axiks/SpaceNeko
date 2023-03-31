using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Manga
{
    public class MangaSynopsisEntity : TextVariantSubItemEntity
    {
        [Required]
        public Guid MangaId { get; set; }
        public MangaEntity Manga { get; set; }
    }
}
