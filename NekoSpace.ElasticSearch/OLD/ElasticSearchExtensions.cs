/*using Nest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NekoSpaceList.Models.Anime;
using NekoSpace.Data.Contracts.Entities.Anime;

namespace NekoSpace.ElasticSearch.OLD
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url)) //OAuth
                .EnableDebugMode()
                .PrettyJson()
                .DefaultIndex(defaultIndex)
                //.EnableApiVersioningHeader()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);


            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
        }

        // Наче це стандартний мапиер ліби
        private static void AddDefaultMappings(ConnectionSettings settings)
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

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<AnimeEntity>(x => x.AutoMap())
            );
        }
    }
}*/