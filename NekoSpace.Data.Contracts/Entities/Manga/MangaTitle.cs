using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaTitle : TextVariantSubItem<Manga>
    {
        [Required]
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public Manga Manga { get => Media; set => Media = value; }
    }
}
