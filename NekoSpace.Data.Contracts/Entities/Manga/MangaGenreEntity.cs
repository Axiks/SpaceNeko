using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaGenreEntity
    {
        public Guid MangaId { get; set; }
        public MangaEntity Manga { set; get; }
        public int GenreId { get; set; }
        public GenreEntity Genre { set; get; }
    }
}
