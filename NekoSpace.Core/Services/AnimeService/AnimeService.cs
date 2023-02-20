using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Data;
using Mapster;
using NekoSpaceList.Models.Anime;
using System.Collections.Generic;
using Arch.EntityFrameworkCore;
using NekoSpace.API.Contracts.Models.SearchService;
using NekoSpace.Data.Contracts.Entities.Anime;

namespace NekoSpace.Core.Services.AnimeService
{
    public class AnimeService
    {
        private ApplicationDbContext _dbContext;
        public AnimeService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
            MapConfigurate();
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

        public SearchAnimeResponse SearchAnimeByName(string query)
        {
            var searchAnime = _dbContext.AnimeTitles
                .Include(i => i.Anime)
                .Where(t => t.Body.Contains(query));

            var searchResult = searchAnime.ToList();

            // Need fix return include object
            var x = searchAnime.ToList();

            List<GetAnimeResponse> findedAnime = new List<GetAnimeResponse>();
            foreach (var anime in searchAnime)
            {
                findedAnime.Add(anime.Adapt<GetAnimeResponse>());
            }


            SearchAnimeResponse searchAnimeResponse = new SearchAnimeResponse{
                TotalCount = findedAnime.Count(),
                Result = findedAnime
            };

            return searchAnimeResponse;
        }

        public bool UpdateAnimeTitle(UpdateAnimeTitleInput updateAnimeTitleInput)
        {
            Guid titleId = updateAnimeTitleInput.TitleId;
            var searchAnime = _dbContext.AnimeTitles
               .FirstOrDefault(t => t.Id == titleId);


            // var result = searchAnime.Adapt<UpdateAnimeTitleInput>();
            return true;
        }

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

            TypeAdapterConfig<AnimeTitleEntity, GetAnimeResponse>.NewConfig()
/*            .Map(
            dest => dest.TitleOriginal,
            src => src.Anime.Titles.FirstOrDefault(x => x.IsOriginal == true))
            .Map(
            dest => dest.SynopsisOriginal,
            src => src.Anime.Synopsises.FirstOrDefault(x => x.IsOriginal == true))
            .Map(
            dest => dest.SynopsisOriginal,
            src => src.Anime.Synopsises.FirstOrDefault(x => x.IsOriginal == true))*/
            .Map(
            dest => dest.NumEpisodes,
            src => src.Anime.NumEpisodes)
            /*.Map(
            dest => dest.PosterOriginal,
            src => src.Anime.Posters.FirstOrDefault().Poster.)*/
            ;
        }
    }
}
