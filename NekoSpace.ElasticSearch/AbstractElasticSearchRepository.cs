using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using NekoSpace.ElasticSearch.Contracts;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using Nest;

namespace NekoSpace.ElasticSearch
{
    public abstract class AbstractElasticSearchRepository<T> : IElasticSearchRepository<T> where T : ElasticSearchModelBasic
    {
        protected readonly IElasticClient _elasticClient;
        protected readonly string _indexName;
        public AbstractElasticSearchRepository(string indexName, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            //var _indexName = configuration["elasticsearch:index"];
            _indexName = indexName;

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

        public abstract Task<ISearchResponse<T>> SearchAsync(ElasticSearchQueryParameters parameters);

        public async Task UpdateAsync(Guid Id, T mediaModel)
        {
            var responsw = await _elasticClient.UpdateAsync<T>(Id, u => u
              .Index(_indexName)
              .Doc(mediaModel));
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
                index => index.Map<T>(x => x.AutoMap())
            );
        }
    }
}
