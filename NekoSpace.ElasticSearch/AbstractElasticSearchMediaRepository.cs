using Microsoft.Extensions.Configuration;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using Nest;

namespace NekoSpace.ElasticSearch
{
    public abstract class AbstractElasticSearchMediaRepository<T> : IElasticSearchRepository<T> where T : ElasticSearchMediaBasicModel
    {
        protected readonly string _indexName;
        protected readonly IElasticClient _elasticClient;
        public AbstractElasticSearchMediaRepository(string indexName, IConfiguration configuration)
        {
            _indexName = indexName;

            var url = configuration["elasticsearch:url"];
            _elasticClient = InitClient(url, _indexName);

            CreateIndex();
        }

        public async Task AddAsync(T mediaModel)
        {
            var response = await _elasticClient.IndexAsync(mediaModel, request => request.Index(_indexName));
        }

        public async Task AddManyAsync(ICollection<T> mediaModels)
        {
            var response = await _elasticClient.IndexManyAsync(mediaModels);
            if (response.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in response.ItemsWithErrors)
                {
                    Console.WriteLine("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task RemoveAsync(T media)
        {
            //await _elasticClient.DeleteAsync<AnimeEntity>(media);

            var response = await _elasticClient.DeleteByQueryAsync<T>(q => q
            .Query(rq => rq
                .Match(m => m
                .Field(f => f.DBId)
                .Query(media.DBId.ToString()))
            )
            .Index(_indexName)
            );
        }

        public async Task RemoveRangeAsync(List<T> mediaList)
        {
            // To optimisation!!
            foreach(var media in mediaList)
            {
                RemoveAsync(media);
            }
        }

        public abstract Task<ISearchResponse<T>> SearchAsync(ElasticSearchQueryParameters parameters);//??

        /*        public async Task<ISearchResponse<ElasticSearchMediaBasicModel>> GetByMediaIdAsync(Guid mediaId)
                {
                    var response = await _elasticClient.SearchAsync<ElasticSearchMediaBasicModel>(m => m
                                    .Index(_indexName)
                                    .Query(q => q
                                      .Bool(bq => bq
                                        .Must( qq =>
                                            qq.Term(t => t.Field(msg => msg.DBId).Value(mediaId))
                                          )
                                      )
                                  )
                             );
                    return response;
                }*/

        public async Task UpdateAsync(T media)
        {
            // Find ES index Id by MediaId // Fix ?
            var findESId = await _elasticClient.SearchAsync<T>(q => q
            .Query(rq => rq
                .Match(m => m
                .Field(f => f.DBId)
                .Query(media.DBId.ToString()))
            )
            .Index(_indexName)
            );
            bool isCurentMediaExist = findESId != null && findESId.Documents.Count != 0;

            if (!isCurentMediaExist) throw new Exception("This record does not exist");

            var response = await _elasticClient.UpdateAsync<T>(findESId.Hits.First().Id, u => u
              .Index(_indexName)
              .Doc(media));
        }




        private ElasticClient InitClient(string url, string indexName)
        {
            var settings = new ConnectionSettings(new Uri(url)) //OAuth
                .EnableDebugMode()
                .PrettyJson()
                .DefaultIndex(indexName)
                //.EnableApiVersioningHeader()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            return new ElasticClient(settings);
        }

        private void CreateIndex()
        {
            var createIndexResponse = _elasticClient.Indices.Create(_indexName,
                index => index.Map<T>( x => x
                    .AutoMap()
                    .Properties(ps => ps
                    //.Object<ElasticSearchMediaBasicModel>(n => n.Name)
                    )
                    .Properties(ps => ps.
                        Nested<ESMediaBasicTitleModel>(n => n
                            .Name(nn => nn.Titles)
                        )
                    )
                    .Properties(ps => ps.
                        Nested<ESMediaBasicTitleModel>(n => n
                            .Name(nn => nn.Synopsises)
                        )
                    )
                )
            );
        }
    }
}
