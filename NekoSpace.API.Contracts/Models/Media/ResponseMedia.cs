using NekoSpace.API.Contracts.Abstract;

namespace NekoSpace.API.Contracts.Models.Media
{
    public class ResponseMedia
    {
        public long TotalHits { get; set; }
        public List<BaseMediaResultDTO>? Result { get; set; }
    }
}
