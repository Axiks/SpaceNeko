using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimePosterEntity
    {
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { set; get; }
        public int PosterId { get; set; }
        public ImageEntity Poster { set; get; }
    }
}
