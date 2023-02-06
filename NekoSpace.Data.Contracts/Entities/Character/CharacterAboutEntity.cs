using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Character
{
    public class CharacterAboutEntity : TextVariantSubItemEntity<CharacterEntity>
    {
        [Required]
        public Guid CharacterId { get => MediaId; set => MediaId = value; }
        public CharacterEntity Character { get => Media; set => Media = value; }
    }
}
