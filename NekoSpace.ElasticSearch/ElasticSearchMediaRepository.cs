using Microsoft.Extensions.Configuration;
using NekoSpace.Common.Enums.API;
using NekoSpace.ElasticSearch.Contracts.General;
using NekoLang = NekoSpace.Data.Contracts.Enums.Language;
using Nest;
using NekoSpace.ElasticSearch.Contracts.Enums;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchMediaRepository : AbstractElasticSearchRepository<ElasticSearchMediaBasicModel, ElasticSearchMediaQueryParameters>
    {
        private static readonly string indexName = IndexNameEnum.Animeindex.ToString() + ", " + IndexNameEnum.MangaIndex.ToString();
        private ElasticSearchMediaQueryParameters _parameters;

        public ElasticSearchMediaRepository(IConfiguration configuration) : base(indexName, configuration)
        {
        }

        private bool CheckSort(MediaSort adaptationType)
        {
            if (_parameters.sort_by == null) return false;
            return _parameters.sort_by.Contains(adaptationType);
        }

        public override async Task<ISearchResponse<ElasticSearchMediaBasicModel>> SearchAsync(ElasticSearchMediaQueryParameters parameters)
        {
            _parameters = parameters;
            // Where adapted
            var adapted = parameters.where_adapted;
            var noAdapted = parameters.where_no_adapted;
            var lang = NekoLang.UK;

            var titleAdapted = adapted != null && adapted.Contains(OfferType.Title);
            var titleNoAdapted = noAdapted != null && adapted.Contains(OfferType.Title);

            var descriptionAdapted = adapted != null && adapted.Contains(OfferType.Description);
            var descriptionNoAdapted = noAdapted != null && adapted.Contains(OfferType.Description);

            // Sort



            var result = await _elasticClient.SearchAsync<ElasticSearchMediaBasicModel>(m => m
                          .Index(_indexName)
                          .From(parameters.offset)
                          .Size(parameters.limit)
                          .Query(q => q
                              .Bool(bq => bq.
                                Filter(
                                  fa => fa.Range(
                                      ta => ta
                                      .Field(f => f.Premiere.Year)
                                      .GreaterThanOrEquals(parameters.from_year_release)
                                      .LessThan(parameters.to_year_release))
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
                              CheckSort(MediaSort.score_asc) ? f => f
                                .Field("_score")
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(MediaSort.score_desc) ? f => f
                                .Field("_score")
                                .Order(SortOrder.Descending) : null
                            )

                            .Field(
                              CheckSort(MediaSort.premiere_date_asc) ? f => f
                                .Field(p => p.Premiere.Year)
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(MediaSort.premiere_date_desc) ? f => f
                                .Field(p => p.Premiere.Year)
                                .Order(SortOrder.Descending) : null
                            )

                            .Field(
                              CheckSort(MediaSort.update_date_asc) ? f => f
                                .Field(p => p.UpdatedAt)
                                .Order(SortOrder.Ascending) : null
                            )
                            .Field(
                              CheckSort(MediaSort.update_date_desc) ? f => f
                                .Field(p => p.UpdatedAt)
                                .Order(SortOrder.Descending) : null
                            )
                          )

                          );

            return result;
        }
    }
}
