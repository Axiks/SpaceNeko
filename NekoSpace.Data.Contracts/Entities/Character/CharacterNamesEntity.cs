using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.CharacterModels;

public class CharacterNamesEntity : TextVariantSubItemEntity<CharacterEntity>
{
    [Required]
    public Guid CharacterId { get => MediaId; set => MediaId = value; }
    public CharacterEntity Character { get => Media; set => Media = value; }
}
