using NekoSpaceList.Models.General;
using NekoSpaceList.Models.Manga;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Manga
{
    public class MangaTitleEntity : TextVariantSubItemEntity<MangaEntity>
    {
        [Required]
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public MangaEntity Manga { get => Media; set => Media = value; }
    }
}
