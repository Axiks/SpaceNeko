using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaSynopsis : TextVariantSubItem<Manga>
    {
        public Guid MangaId { get => MediaId; set => MediaId = value; }
        public Manga Manga { get => Media; set => Media = value; }
    }
}
