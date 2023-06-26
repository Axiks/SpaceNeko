using NekoSpace.Data.Contracts.Entities.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Base
{
    public abstract class MediaEntity
    {
        public Guid Id { get; set; }
        public ICollection<AssociatedServiceEntity> AnotherService { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
