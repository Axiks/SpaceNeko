using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeCover
    {
        public Guid AnimeId { get; set; }
        public Anime Anime { set; get; }
        public int CoverId { get; set; }
        public Image Cover { set; get; }
    }
}
