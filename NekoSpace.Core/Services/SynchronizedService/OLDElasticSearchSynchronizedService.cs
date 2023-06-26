/*using JikanDotNet;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.Core.Contracts.Interfaces;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpaceList.Models.Anime;
using Nest;
using System.Xml.Linq;

namespace NekoSpace.Core.Services.SynchronizedService
{
    public class OLDElasticSearchSynchronizedService : IElasticSearchSynchronizedService<AnimeEntity>
    {
        private readonly IElasticClient _elasticClient;
        private readonly string _indexName;
        public OLDElasticSearchSynchronizedService(IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var _indexName = configuration["elasticsearch:index"];

            _elasticClient = InitClient(url, _indexName);
            CreateIndex();
        }

        public async Task AddAsync(AnimeEntity mediaModel)
        {
            var response = await _elasticClient.IndexAsync(mediaModel, request => request.Index(_indexName));
        }

        public async Task AddManyAsync(ICollection<AnimeEntity> mediaModels)
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

        public async Task RemoveAsync(AnimeEntity media)
        {
            //await _elasticClient.DeleteAsync<AnimeEntity>(media);

            var response = await _elasticClient.DeleteByQueryAsync<MediaEntity>(q => q
            .Query(rq => rq
                .Match(m => m
                .Field(f => f.Id)
                .Query(media.Id.ToString()))
            )
            .Index(_indexName)
        );
        }

        public async Task SearchAsync(ElasticSearchQueryParameters parameters)
        {
            var result = _elasticClient.
                SearchAsync<AnimeEntity>(s => s
                .Index(_indexName)
                .Query(q => q.
                    Match(m => m
                    .Field(f => f.Body)
                        .Query(parameters.q)
                        )
                    )
                );
        }

        public async Task UpdateAsync(Guid Id, AnimeEntity mediaModel)
        {
            var responsw = await _elasticClient.UpdateAsync<AnimeEntity>(Id, u => u
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

            CreateDefaultMappings(settings);

            return new ElasticClient(settings);
        }

        private static void CreateDefaultMappings(ConnectionSettings settings)
        {
            settings
                .DefaultMappingFor<AnimeEntity>(m => m
                    .Ignore(p => p.Posters)
                    .Ignore(p => p.Covers)
                    .Ignore(p => p.RatingInUsers)
                    .Ignore(p => p.FavoriteInUsers)
                    .Ignore(p => p.ViewingStatusInUsers)
                    .Ignore(p => p.CreatedAt)
                    //.Ignore(p => p.Titles)
                    .Ignore(p => p.Synopsises)
                    .Ignore(p => p.Genres)
                    .Ignore(p => p.Characters)
                )
                .DefaultMappingFor<AnimeTitleEntity>(m => m
                    .Ignore(p => p.AnimeId)
                    .Ignore(p => p.Anime)
                );
        }

        private void CreateIndex()
        {
            var createIndexResponse = _elasticClient.Indices.Create(_indexName,
                index => index.Map<AnimeEntity>(x => x.AutoMap())
            );
        }
    }
}
*/