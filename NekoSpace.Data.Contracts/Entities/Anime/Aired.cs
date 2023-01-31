using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class Aired : ITimePeriod
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
