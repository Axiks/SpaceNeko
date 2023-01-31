using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimePoster
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public int PosterId { get; set; }
        public Image Poster { set; get; }
    }
}
