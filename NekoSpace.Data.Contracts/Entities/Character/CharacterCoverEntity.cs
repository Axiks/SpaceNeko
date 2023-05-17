using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class CharacterCoverEntity
    {
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { set; get; }
        public int CoverId { get; set; }
        public ImageEntity Cover { set; get; }
    }
}
