using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public partial class GeneralModel
    {
        public abstract class TimePeriod
        {
            public Guid Id { get; set; }
            [Required]
            public DateTime? From { get; set; }
            public DateTime? To { get; set; }
        }
    }
}
