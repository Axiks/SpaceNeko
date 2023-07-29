using Microsoft.Extensions.Configuration;
using NekoSpace.Common.Enums.API;
using NekoLang = NekoSpace.Data.Contracts.Enums.Language;
using Nest;
using System.Linq;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchAnimeRepository : AbstractElasticSearchRepository<ElasticSearchAnimeModel>
    {
        private static readonly string indexName = "animeindex";
        private ElasticSearchQueryParameters _parameters;

        public ElasticSearchAnimeRepository(IConfiguration configuration) : base(indexName, configuration)
        {
        }

        private bool CheckSort(AnimeSort adaptationType)
        {
            if(_parameters.sort_by == null) return false;
            return _parameters.sort_by.Contains(adaptationType);
        }

        public override async Task<ISearchResponse<ElasticSearchAnimeModel>> SearchAsync(ElasticSearchQueryParameters parameters)
        {
            _parameters = parameters;
            // Where adapted
            var adapted = parameters.where_adapted;
            var noAdapted = parameters.where_no_adapted;
            var lang = NekoLang.UK;

            var titleAdapted = adapted != null && adapted.Contains(AdaptationType.Title);
            var titleNoAdapted = noAdapted != null && adapted.Contains(AdaptationType.Title);

            var descriptionAdapted = adapted != null && adapted.Contains(AdaptationType.Description);
            var descriptionNoAdapted = noAdapted != null && adapted.Contains(AdaptationType.Description);

            // Sort
            


            var result = await _elasticClient.SearchAsync<ElasticSearchAnimeModel>(m => m
                          .Index(_indexName)
                          .From(parameters.offset)
                          .Size(parameters.limit)
                          .Query(q => q
                              .Bool(bq => bq.
                                Must( 
                                  fa => fa.Range(
                                      ta => ta
                                      .Field(f => f.NumEpisodes)
                                      .GreaterThanOrEquals(parameters.min_episodes)
                                      .LessThan(parameters.max_episodes)),
                                  fa => fa.Range(
                                      ta => ta
                                      .Field(f => f.Premiere.Year)
                                      .GreaterThanOrEquals(parameters.from_year_release)
                                      .LessThan(parameters.to_year_release)),
                                  fa => fa.Term(
                                          rn => rn.Field(msg => msg.Premiere.Season).Value(parameters.sezon)),
                                  fa => fa.Term(
                                          rn => rn.Field(msg => msg.AiringStatus).Value(parameters.airing_status))
                                  )
                                .Must(mq => mq
                                    .Nested(n => n
                                    .Path(msg => msg.Titles)
                                    .Query(nq => nq
                                        .Bool(bq => bq
                                            .Must(
                                                fq => fq.Match(t => t.Field(msg => msg.Titles[0].Body).Query(parameters.q))
                                            )
                                            .Filter(
                                                titleAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].Language).Value(lang)) : null,
                                                titleAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].IsMain).Value(true)) : null,

                                                titleNoAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].Language).Value(lang)) : null,
                                                titleNoAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].IsMain).Value(false)) : null,


                                                descriptionAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].Language).Value(lang)) : null,
                                                descriptionAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].IsMain).Value(true)) : null,

                                                descriptionNoAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].Language).Value(lang)) : null,
                                                descriptionNoAdapted ? fq => fq.Term(t => t.Field(msg => msg.Titles[0].IsMain).Value(false)) : null
                                            )
                                        )
                                    )
                                )

                              )))
                          .Sort(ss => ss
                            .Field(
                              CheckSort(AnimeSort.score_asc) ? f => f
                                .Field("_score")
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(AnimeSort.score_desc) ? f => f
                                .Field("_score")
                                .Order(SortOrder.Descending) : null
                            )

                            .Field(
                              CheckSort(AnimeSort.episodes_num_asc) ? f => f
                                .Field(p => p.NumEpisodes)
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(AnimeSort.episodes_num_desc) ? f => f
                                .Field(p => p.NumEpisodes)
                                .Order(SortOrder.Descending) : null
                            )

                            .Field(
                              CheckSort(AnimeSort.premiere_date_asc) ? f => f
                                .Field(p => p.Premiere.Year)
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(AnimeSort.premiere_date_desc) ? f => f
                                .Field(p => p.Premiere.Year)
                                .Order(SortOrder.Descending) : null
                            )

                            .Field(
                              CheckSort(AnimeSort.update_date_asc) ? f => f
                                .Field(p => p.UpdatedAt)
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(AnimeSort.update_date_desc) ? f => f
                                .Field(p => p.UpdatedAt)
                                .Order(SortOrder.Descending) : null
                            )
                          )
                          
                          );

            return result;
        }

    }
}
