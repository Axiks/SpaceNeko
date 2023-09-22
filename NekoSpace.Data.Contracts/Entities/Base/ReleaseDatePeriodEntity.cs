using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public abstract class ReleaseDatePeriodEntity
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
