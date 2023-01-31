using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeGenre
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public int GenreId { get; set; }
        public Genre Genre { set; get; }
    }
}
