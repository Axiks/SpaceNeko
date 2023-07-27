using NekoSpace.API.Contracts.Abstract;
using NekoSpace.API.Contracts.Models.AnimeService;

namespace NekoSpace.API.Contracts.Models.Media
{
    public class ResponseMedia
    {
        public long total { get { return anime.total; } }
        public GetMediaListDTO<GetAnimeResultDTO>? anime { get; set; }
    }

    public class GetMediaListDTO<T> where T : BaseMediaResultDTO
    {
        public long total { get; set; } = 0;
        public List<GetAnimeResultDTO>? results { get; set; }
    }
}
