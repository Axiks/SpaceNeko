using NekoSpace.API.Contracts.Abstract;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.Data.Contracts.Enums;
using NekoSpaceList.Models.Anime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.AnimeService
{
    public class GetAnimeResultDTO : BaseMediaResultDTO
    {
        [Required]
        public int? NumEpisodes { get; set; }//+
        //public int? EpisodesDurationSeconds { get; set; }//+
        public AnimeType AnimeType { get; set; }//+
        public AiringStatus AiringStatus { get; set; }//+
    }
}