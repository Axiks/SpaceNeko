using NekoSpace.API.Contracts.Models.Basic.Media;
using NekoSpace.Common.Enums.API;
using NekoSpace.Data.Contracts.Enums;

namespace NekoSpace.API.Contracts.Models.Anime
{
    public class GetAnimeQueryParameters : MediaQueryParametersBasic
    {
        public int? min_episodes { get; set; }
        public int? max_episodes { get; set; }
        //public int? min_episode_duration { get; set; }
        //public int? max_episode_duration { get; set; }
        public Season? sezon { get; set; }
        public AiringStatus? airing_status { get; set; }
        //public List<AgeRating>? age_ratings { get; set; }
        //public List<AnimeType>? anime_types { get; set; }

        public List<AnimeSort>? sort_by { get; set; }
    }
}
