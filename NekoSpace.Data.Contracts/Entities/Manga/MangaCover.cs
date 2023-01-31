using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaCover
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public int CoverId { get; set; }
        public Image Cover { set; get; }
    }
}
