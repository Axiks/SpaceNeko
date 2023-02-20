using NekoSpace.API.Contracts.Models.AnimeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.SearchService
{
    public class SearchAnimeResponse
    {
        public int TotalCount { get; set; } = 0;
        public List<GetAnimeResponse> Result { get; set; } = new List<GetAnimeResponse>();
    }
}
