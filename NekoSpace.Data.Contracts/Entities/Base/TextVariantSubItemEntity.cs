using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NekoSpaceList.Models.General
{
    public abstract class TextVariantSubItemEntity<T> where T : MediaEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Body { get; set; }
        public bool LanguageDetectionBySystem { get; set; } = false;
        [Required]
        public Language Language { get; set; }
        [Required]
        public ItemFrom From { get; set; }
        [Required]
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
        [NotMapped]
        private protected Guid MediaId { get; set; }
        [NotMapped]
        private protected T Media { get; set; }
        public bool? IsAcceptProposal { get; set; }
        [Required]
        public bool IsHidden { get; set; } = false;
        public Guid? CreatorUserId { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }

}
