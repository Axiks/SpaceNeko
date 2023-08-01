using NekoSpace.API.Contracts.Abstract;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.Manga;
using Swashbuckle.AspNetCore.Annotations;

namespace NekoSpace.API.Contracts.Models.Media
{
    public class ResponseMedia
    {
        public long TotalHits { get; set; }
        public List<BaseMediaResultDTO>? Result { get; set; }
    }
}
