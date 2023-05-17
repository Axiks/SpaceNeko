using NekoSpace.Data.Contracts.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public abstract class TextVariantSubItemEntity : RootVariantSubItemEntity
    {
        [Required]
        public string Body { get; set; }
        public bool LanguageDetectionBySystem { get; set; } = false;
    }
}
