using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.CharacterModels;

public class CharacterNamesEntity : TextVariantSubItemEntity
{
    [Required]
    public Guid CharacterId { get; set; }
    public CharacterEntity Character { get; set; }
}
