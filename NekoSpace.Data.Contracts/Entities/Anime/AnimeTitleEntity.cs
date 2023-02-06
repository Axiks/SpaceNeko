using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Anime
{
    public class AnimeTitleEntity : TextVariantSubItemEntity<AnimeEntity>
    {
        [Required]
        public Guid AnimeId { get => MediaId; set => MediaId = value; }
        public AnimeEntity Anime { get => Media; set => Media = value; }
    }
}
