/*using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpaceList.Models.Anime;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NekoSpace.ElasticSearch.OLD
{
    public class OLDESAnimeService
    {
        private readonly IElasticClient _elasticClient;

        public OLDESAnimeService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
            var p = _elasticClient.Ping();
            Console.WriteLine(p);
        }

        public async Task SaveSingleAsync(AnimeEntity anime)
        {
            // await _elasticClient.UpdateAsync<Product>(product, u => u.Doc(product));
            //await _elasticClient.IndexDocumentAsync(anime);
            //await _elasticClient.IndexDocumentAsync(anime);
            var response = await _elasticClient.IndexAsync(anime, request => request.Index("animes"));

            if (response.IsValid)
            {
                Console.WriteLine($"Index document with ID {response.Id} succeeded.");
            }
        }

        public async Task SaveManyAsync(AnimeEntity[] anime)
        {
            var result = await _elasticClient.IndexManyAsync(anime);
            if (result.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in result.ItemsWithErrors)
                {
                    Console.WriteLine("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }
        *//* public async Task SearchAnimeAsync(AnimeEntity anime)
         {
             await ;
         }*//*

        public IList<AnimeEntity> GetAnime(GetAnimeQueryParameters getAnimeQueryParameters)
        {
            *//* var result = _elasticClient.
                 SearchAsync<AnimeEntity>(s => s
                 .Index("animes")
                 //.From(getAnimeQueryParameters.offset)
                 //.Size(getAnimeQueryParameters.limit)
                 .Query(q => q
                     .Nested(n => n
                         .Path(p => p.Titles)
                         .Query(nq => nq
                             .Nested(m => m
                                 .Path(f => f.)
                                 .Query()
                             )
                         )
                     )
                 )ult = _elasticClient.
                 SearchAsync<AnimeTitleEntity>(s => s
                 .Index("animes")
                 .From(getAnimeQueryParameters.offset)
                 .Size(getAnimeQueryParameters.limit)
                 .Query(q => q
                    .Term(t => t.Body, getAnimeQueryParameters.q)
                 //.Nested
                 )
                 );*/

            /* var result = _elasticClient.
                 SearchAsync<AnimeEntity>(s => s
                 .Index("animes")
                 .From(getAnimeQueryParameters.offset)
                 .Size(getAnimeQueryParameters.limit)
                 .Query(q => q.
                     QueryString(d => d.
                         Query('*' + getAnimeQueryParameters.q + '*')
                         )
                     )
                 );*/

            /*var preRes = _elasticClient.
                SearchAsync<AnimeTitleEntity>(s => s
                .Index("animes")
                 .Query(q => q.Match(
                     m => m
                        .Field(f => f.Body)
                        .Query("Russ")
                     )
                 )
            );*/

            /*var result = _elasticClient.
                SearchAsync<AnimeEntity>(s => s
                .Index("animes")
                //.From(getAnimeQueryParameters.offset)
                //.Size(getAnimeQueryParameters.limit)
                .Query(q => q.
                    Match(m => m
                        .Field(f => f.Titles.Select(h=> h.Body))
                        .Query(getAnimeQueryParameters.q)
                    )
                    )
                );*//*

            var result = _elasticClient.
                SearchAsync<AnimeTitleEntity>(s => s
                .Index("animes")
                .Query(q => q.
                    Match(m => m
                        .Field(f => f.Body)
                        .Query(getAnimeQueryParameters.q)
                        )
                    )
                );


            var finalResult = result;
            var finalContent = finalResult.Result;
            var h1 = finalContent.Hits;
            var h2 = finalContent.HitsMetadata;
            var finalContentList = finalContent.Documents.ToList();
            //return finalContentList;
            return null;
        }

        public async Task SaveBulkAsync(AnimeEntity[] anime)
        {
            var result = await _elasticClient.BulkAsync(b => b.Index("anime").IndexMany(anime));
            if (result.Errors)
            {
                // the response can be inspected for errors
                foreach (var itemWithError in result.ItemsWithErrors)
                {
                    Console.WriteLine("Failed to index document {0}: {1}",
                        itemWithError.Id, itemWithError.Error);
                }
            }
        }

        public async Task DeleteAsync(AnimeEntity anime)
        {
            await _elasticClient.DeleteAsync<AnimeEntity>
        (anime);
        }
    }
}
*/