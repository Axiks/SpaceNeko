using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaPosterEntity
    {
        public Guid MangaId { get; set; }
        public MangaEntity Manga { set; get; }
        public int PosterId { get; set; }
        public ImageEntity Poster { set; get; }
    }
}
