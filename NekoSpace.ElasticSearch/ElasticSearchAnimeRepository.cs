using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchAnimeRepository : AbstractElasticSearchRepository<ElasticSearchAnimeModel>
    {
        private static readonly string indexName = "animeindex";

        public ElasticSearchAnimeRepository(IConfiguration configuration) : base(indexName, configuration)
        {
        }

        public override async Task<ISearchResponse<ElasticSearchAnimeModel>> SearchAsync(ElasticSearchQueryParameters parameters)
        {
            /*var result = await _elasticClient.SearchAsync<ElasticSearchAnimeModel>(m => m
                          .Index(_indexName)
                          .From(parameters.offset)
                          .Size(parameters.limit)
                          .Query(q => q
                            .Term(t => t
                              .Field(msg => msg.Titles[0].Body)
                              .Value(parameters.q))));*/

            var result = await _elasticClient.SearchAsync<ElasticSearchAnimeModel>(m => m
                          .Index(_indexName)
                          .From(parameters.offset)
                          .Size(parameters.limit)
                          .Query(q => q
                            .Nested(t => t
                              .Path(msg => msg.Titles)
                              .Query(nq =>
                                //nq.Term(t => t.Field(msg => msg.NumEpisodes).Value(parameters.q)) &&
                                nq.Term(t => t.Field(msg => msg.Titles[0].Body).Value(parameters.q))
                              )
                            )
                          )
                        );

            return result;
        }

    }
}
