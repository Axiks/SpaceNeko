using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Data;
using Mapster;
using NekoSpaceList.Models.Anime;
using System.Collections.Generic;
using Arch.EntityFrameworkCore;

namespace NekoSpace.Core.Services.AnimeService
{
    public class AnimeService
    {
        private ApplicationDbContext _dbContext;
        public AnimeService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
            // MapConfigurate();
        }
        public List<GetAnimeResponse> GetAnimeList(int limit, int offset)
        {
            var animeContext = _dbContext.Animes
                .Include(g => g.Titles).ToList();

            List<GetAnimeResponse> getAnimeResponses= new List<GetAnimeResponse>();
            foreach (var anime in animeContext) {
                var x = anime;
                //var response = anime.Adapt<GetAnimeResponse>();
                //getAnimeResponses.Add(response);
            }

            return getAnimeResponses;
        }

        public GetAnimeResponse GetAnimeById(Guid animeId)
        {
            var anime = _dbContext.Animes.Where(a => a.Id== animeId).FirstOrDefault();

            var response = anime.Adapt<GetAnimeResponse>();
            return response;

        }

        // Search
        // var searchAnime2 = dbContext.AnimeTitles.Include(i => i.Anime).Where(t => t.Body.Contains(input.query));

        private void MapConfigurate()
        {
            TypeAdapterConfig<AnimeEntity, GetAnimeResponse>.NewConfig()
            .Map(
            dest => dest.TitleOriginal,
            src => src.Titles.First().Body)
            .Map(
            dest => dest.SynopsisOriginal,
            src => src.Synopsises.First().Body)
            .Map(
            dest => dest.PosterOriginal,
            src => src.Posters.First().Poster.Original);
        }
    }
}
