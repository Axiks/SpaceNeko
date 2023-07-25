using NekoSpace.Common.Enums.API;
using NekoSpace.Data.Contracts.Enums;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchQueryParameters
    {
        public string? q { get; set; }
        public int limit { get; set; } = 40;
        public int offset { get; set; } = 0;
        public int? min_episodes { get; set; }
        public int? max_episodes { get; set; }
        //public int? min_episode_duration { get; set; }
        //public int? max_episode_duration { get; set; }
        public int? from_year_release { get; set; }
        public int? to_year_release { get; set; }
        public Sezon? sezon { get; set; }
        public AiringStatus? airing_status { get; set; }
        public List<AnimeType>? anime_types { get; set; }
        //public List<AgeRating>? age_ratings { get; set; }
        public List<AdaptationType>? where_adapted { get; set; }
        public List<AdaptationType>? where_no_adapted { get; set; }

        public List<AnimeSort>? sort_by { get; set; }
    }
}
