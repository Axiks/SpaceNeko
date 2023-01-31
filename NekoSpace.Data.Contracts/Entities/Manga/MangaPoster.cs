using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaPoster
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public int PosterId { get; set; }
        public Image Poster { set; get; }
    }
}
