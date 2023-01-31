using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.CharacterModels
{
    public class CharacterNames : TextVariantSubItem<Character>
    {
        [Required]
        public Guid CharacterId { get => MediaId; set => MediaId = value; }
        public Character Character { get => Media; set => Media = value; }
    }
}
