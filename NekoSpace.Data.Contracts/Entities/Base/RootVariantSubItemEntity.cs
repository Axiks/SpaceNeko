using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Data.Models.User;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public abstract class RootVariantSubItemEntity
    {
        public Guid Id { get; set; }
        public Language? Language { get; set; } // region
        [Required]
        public Guid MediaId { get; set; }
        public MediaEntity Media { get; set; }

        [Required]
        public ItemFrom From { get; set; }
        [Required]
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
        public bool? IsAcceptProposal { get; set; }
        public bool IsHidden { get; set; } = false;
        public string? CreatorUserId { get; set; }
        public UserEntity? CreatorUser { get; set; }
        public Guid? AcceptOfferUserId { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }

}
