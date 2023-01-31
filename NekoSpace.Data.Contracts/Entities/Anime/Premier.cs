using NekoSpace.Data.Contracts.Entities.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.Anime
{
    public class Premier
    {
        public Guid Id { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public Sezon Sezon { get; set; }
    }
}
