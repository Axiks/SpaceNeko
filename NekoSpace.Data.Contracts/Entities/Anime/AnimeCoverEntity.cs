using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeCoverEntity
    {
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { set; get; }
        public int CoverId { get; set; }
        public ImageEntity Cover { set; get; }
    }
}
