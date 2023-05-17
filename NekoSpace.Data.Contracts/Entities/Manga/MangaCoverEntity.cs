using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaCoverEntity
    {
        public Guid MangaId { get; set; }
        public MangaEntity Manga { set; get; }
        public int CoverId { get; set; }
        public ImageEntity Cover { set; get; }
    }
}
