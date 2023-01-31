using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeSynopsis : TextVariantSubItem<Anime>
    {
        public Guid AnimeId { get => MediaId; set => MediaId = value; }
        public Anime Anime { get => Media; set => Media = value; }
    }
}
