using Microsoft.Extensions.Configuration;
using Nest;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchMangaRepository : AbstractElasticSearchMediaRepository<ElasticSearchMangaModel>
    {
        private static readonly string indexName = "mangaindex";

        public ElasticSearchMangaRepository(IConfiguration configuration) : base(indexName, configuration)
        {
        }

        public override async Task<ISearchResponse<ElasticSearchMangaModel>> SearchAsync(ElasticSearchQueryParameters parameters)
        {

            var result = await _elasticClient.SearchAsync<ElasticSearchMangaModel>(m => m
                          .Index(_indexName)
                          .From(parameters.offset)
                          .Size(parameters.limit)
                          .Query(q => q
                            .Nested(t => t
                              .Path(msg => msg.Titles)
                              .Query(nq =>
                                nq.Term(t => t.Field(msg => msg.Titles[0].Body).Value(parameters.q))
                              )
                            )
                          )
                        );

            return result;
        }

    }
}
