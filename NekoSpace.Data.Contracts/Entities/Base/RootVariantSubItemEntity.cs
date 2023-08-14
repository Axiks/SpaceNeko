using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public abstract class RootVariantSubItemEntity
    {
        public Guid Id { get; set; }
        public Language? Language { get; set; } // region

        [Required]
        public ItemFrom From { get; set; }
        [Required]
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
        public bool? IsAcceptProposal { get; set; }
        public bool IsHidden { get; set; } = false;
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }

}
