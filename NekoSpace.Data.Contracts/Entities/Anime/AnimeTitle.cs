using System.ComponentModel.DataAnnotations;
using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnimeTitle : TextVariantSubItem<Anime>
    {
        [Required]
        public Guid AnimeId { get => MediaId; set => MediaId = value; }
        public Anime Anime { get => Media; set => Media = value; }
    }
}
