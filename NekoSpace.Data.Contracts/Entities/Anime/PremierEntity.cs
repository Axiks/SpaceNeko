using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.Anime
{
    public class PremierEntity
    {
        public Guid Id { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public Season? Season { get; set; }
    }
}
