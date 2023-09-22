using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Character
{
    public class CharacterAboutEntity : TextVariantSubItemEntity
    {
        [Required]
        public Guid CharacterId { get; set; }
        public CharacterEntity Character { get; set; }
    }
}
