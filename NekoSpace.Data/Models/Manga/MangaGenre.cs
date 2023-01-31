using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Manga
{
    public class MangaGenre
    {
        public Guid MangaId { get; set; }
        public Manga Manga { set; get; }
        public int GenreId { get; set; }
        public Genre Genre { set; get; }
    }
}
