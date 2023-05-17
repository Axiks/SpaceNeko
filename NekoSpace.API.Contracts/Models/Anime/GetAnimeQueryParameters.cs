using NekoSpace.Common.Enums.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.Anime
{
    public class GetAnimeQueryParameters
    {
        public string? q { get; set; }
        public int limit { get; set; } = 40;
        public int offset { get; set; } = 0;
        public int? min_episodes { get; set; }
        public int? max_episodes { get; set; }
        public int? min_episode_duration { get; set; }
        public int? max_episode_duration { get; set; }
        public List<AnimeSort>? sort_by { get; set; }
    }
}
