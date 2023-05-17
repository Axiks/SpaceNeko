using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeGenreEntity
    {
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { set; get; }
        public int GenreId { get; set; }
        public GenreEntity Genre { set; get; }
    }
}
