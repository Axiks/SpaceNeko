using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchAnimeModel : ElasticSearchMediaBasicModel
    {
        public int? NumEpisodes { get; set; }
        public int? EpisodesDurationSeconds { get; set; }
        public AnimeType Type { get; set; }
        public AiringStatus AiringStatus { get; set; }
        public ESReleaseDatePeriod ReleaseDatePeriod { get; set; }
    }
}
