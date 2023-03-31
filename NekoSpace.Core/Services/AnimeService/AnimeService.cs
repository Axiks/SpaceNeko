using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Data;
using Mapster;
using NekoSpaceList.Models.Anime;
using NekoSpace.API.Contracts.Models.SearchService;
using NekoSpace.Data.Contracts.Entities.Anime;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Collections.Generic;

namespace NekoSpace.Core.Services.AnimeService
{
    public class AnimeService
    {
        private ApplicationDbContext _dbContext;
        public AnimeService(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
            MapConfigurate();
        }
        public async Task<List<GetAnimeResultDTO>> GetAnimeList(string? query, int limit, int offset)
        {
            var animeListContextAsync = query == string.Empty ? TakeAllAnimeAsync(limit, offset) : FindAnimesAsync(query, limit, offset);

            List<GetAnimeResultDTO> getAnimeResponses = new List<GetAnimeResultDTO>();
            animeListContextAsync.Wait();

            foreach (var anime in animeListContextAsync.Result) {
                var x = anime;
                var response = anime.Adapt<GetAnimeResultDTO>();
                getAnimeResponses.Add(response);
            }

            return getAnimeResponses;
        }

        public async Task<GetAnimeResultDTO> GetAnimeById(Guid animeId)
        {
            var anime = _dbContext.Animes
                .Include(x => x.Titles)
                .Include(x => x.Synopsises)
                .Include(x => x.Posters).ThenInclude(x => x.Poster)
                .FirstOrDefault(a => a.Id == animeId);

            var response = anime.Adapt<GetAnimeResultDTO>();
            return response;
        }

        public async Task<SearchAnimeResultDTO> SearchAnimeByName(string query)
        {
            var searchAnime = _dbContext.AnimeTitles
                .Include(i => i.Anime).ThenInclude(x => x.Titles)
                .Include(i => i.Anime).ThenInclude(x => x.Synopsises)
                .Include(i => i.Anime).ThenInclude(x => x.Posters).ThenInclude(x => x.Poster)
                .Where(t => t.Body.Contains(query));

            var searchResultAsync = searchAnime.ToListAsync();
            searchResultAsync.Wait();

            List<GetAnimeResultDTO> findedAnime = new List<GetAnimeResultDTO>();
            foreach (var animeTitile in searchResultAsync.Result)
            {
                findedAnime.Add(animeTitile.Anime.Adapt<GetAnimeResultDTO>());
            }

            SearchAnimeResultDTO searchAnimeResponse = new SearchAnimeResultDTO{
                TotalCount = findedAnime.Count(),
                Result = findedAnime
            };

            return searchAnimeResponse;
        }

        public async Task<bool> UpdateAnimeTitle(UpdateAnimeTitle updateAnimeTitleInput)
        {
            Guid titleId = updateAnimeTitleInput.TitleId;
            var searchAnime = await _dbContext.AnimeTitles
               .FirstOrDefaultAsync(t => t.Id == titleId);

            // var result = searchAnime.Adapt<UpdateAnimeTitleInput>();
            return true;
        }

        private async Task<List<AnimeEntity>> TakeAllAnimeAsync(int limit, int offset)
        {
            var animeListContext = _dbContext.Animes
                .Include(g => g.Titles)
                .Include(x => x.Synopsises)
                .Include(x => x.Posters).ThenInclude(x => x.Poster)
                .Skip(offset)
                .Take(limit);

            return await animeListContext.ToListAsync();
        }

        private async Task<List<AnimeEntity>> FindAnimesAsync(string query, int limit, int offset)
        {
            var animeListContext = _dbContext.Animes
                .Include(g => g.Titles)
                .Where(x => x.Titles.Any(o => o.Body.Contains(query)))
                .Include(x => x.Synopsises)
                .Include(x => x.Posters).ThenInclude(x => x.Poster)
                .Skip(offset)
                .Take(limit);

            return await animeListContext.ToListAsync();
        }

        private void MapConfigurate()
        {
            TypeAdapterConfig<AnimeEntity, GetAnimeResultDTO>.NewConfig()
            .Map(
                dest => dest.TitleOriginal,
                src => src.Titles.FirstOrDefault(x => x.IsOriginal == true).Body)
            .IgnoreIf((src, dest) => src.Synopsises.IsNullOrEmpty(), src => src.SynopsisOriginal)
            .Map(
               dest => dest.SynopsisOriginal,
               src => src.Synopsises.First().Body
            )
            .IgnoreIf((src, dest) => src.Posters.IsNullOrEmpty(), src => src.PosterOriginal)
            .Map(
            dest => dest.PosterOriginal,
            src => src.Posters.First().Poster.Original);

            TypeAdapterConfig<AnimeTitleEntity, GetAnimeResultDTO>.NewConfig()
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
