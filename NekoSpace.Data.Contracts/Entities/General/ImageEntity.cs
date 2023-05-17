using NekoSpace.Data.Contracts.Enums;
using NekoSpaceList.Models.Anime;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public partial class GeneralModel
    {
        public class ImageEntity
        {
            public int Id { get; set; }
            [Required]
            public string Original { get; set; }
            public string? Large { get; set; }
            public string? Medium { get; set; }
            public string? Small { get; set; }
            [Required]
            public ItemFrom From { get; set; }
            public AnimePosterEntity Posters { get; set; }
        }
    }
}
