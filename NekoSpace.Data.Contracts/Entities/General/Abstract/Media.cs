using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.General.Abstract
{
    public abstract class Media
    {
        public Guid Id { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
