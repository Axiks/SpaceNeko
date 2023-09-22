using Microsoft.Extensions.Configuration;
using Nest;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchMediaRepository : AbstractElasticSearchMediaRepository<ElasticSearchMediaBasicModel>
    {
        public ElasticSearchMediaRepository(string indexName, IConfiguration configuration) : base(indexName, configuration)
        {
        }

        public async Task<ISearchResponse<ElasticSearchMediaBasicModel>> GetByMediaIdAsync(Guid mediaId)
        {
            var response = await _elasticClient.SearchAsync<ElasticSearchMediaBasicModel>(m => m
                            .Index(_indexName)
                            .Query(q => q
                              .Bool(bq => bq
                                .Must(qq =>
                                    qq.Term(t => t.Field(msg => msg.DBId).Value(mediaId))
                                  )
                              )
                          )
                     );
            return response;
        }

        public override Task<ISearchResponse<ElasticSearchMediaBasicModel>> SearchAsync(ElasticSearchQueryParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
