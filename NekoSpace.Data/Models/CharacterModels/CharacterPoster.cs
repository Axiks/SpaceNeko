using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class CharacterPoster
    {
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
        public int PosterId { get; set; }
        public Image Poster { set; get; }
    }
}
