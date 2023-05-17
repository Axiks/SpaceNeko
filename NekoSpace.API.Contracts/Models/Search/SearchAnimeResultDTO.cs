using NekoSpace.API.Contracts.Models.AnimeService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.SearchService
{
    public class SearchAnimeResultDTO
    {
        [Required]
        public int TotalCount { get; set; } = 0;
        [Required]
        public List<GetAnimeResultDTO> Result { get; set; } = new List<GetAnimeResultDTO>();
    }
}
