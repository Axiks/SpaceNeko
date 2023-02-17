using NekoSpace.API.Contracts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.AnimeService
{
    public class GetAnimeResponse : BaseItem
    {
        public string TitleOriginal { get; set; }
        public string SynopsisOriginal { get; set; }
        public string PosterOriginal { get; set; }
        public int? NumEpisodes { get; set; }
        public int? EpisodesDurationSeconds { get; set; }

    }
}