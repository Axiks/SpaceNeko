using NekoSpace.Data.Contracts.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.General
{
    public class AssociatedServiceEntity
    {
        public Guid Id { get; set; }
        public Guid MediaId { get; set; }
        public MediaEntity Media { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
