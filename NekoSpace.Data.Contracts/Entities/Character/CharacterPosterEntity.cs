using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class CharacterPosterEntity
    {
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { set; get; }
        public int PosterId { get; set; }
        public ImageEntity Poster { set; get; }
    }
}
