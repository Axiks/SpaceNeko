using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NekoSpace.Data.Contracts.Entities.Anime
{
    public class AnimeTitleEntity : TextVariantSubItemEntity
    {
        public Guid AnimeId { get; set; }
        public AnimeEntity Anime { get; set; }
    }
}
