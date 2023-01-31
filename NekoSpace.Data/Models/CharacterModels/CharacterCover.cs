using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class CharacterCover
    {
        public Guid CharacterId { get; set; }
        public Character Character { set; get; }
        public int CoverId { get; set; }
        public Image Cover { set; get; }
    }
}
