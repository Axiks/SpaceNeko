using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Data;
using Mapster;
using NekoSpaceList.Models.Anime;
using NekoSpace.API.Contracts.Models.SearchService;
using NekoSpace.Data.Contracts.Entities.Anime;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.Common.Enums.API;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository;
using NekoSpace.Repository.Repositories;
using JikanDotNet;
using NekoSpace.API.Contracts.Models.Media;

namespace NekoSpace.Core.Services.AnimeService
{
    public class AnimeService
    {
        private ApplicationDbContext _dbContext;
        private AnimeRepository _animeRepository;
        public AnimeService(ApplicationDbContext dbContext, AnimeRepository animeRepository) {
            _dbContext = dbContext;
            _animeRepository = animeRepository;
            MapConfigurate();
        }
        public async Task<GetMediaListDTO<GetAnimeResultDTO>> GetAnimeList(GetAnimeQueryParameters parameters)
        {
            var animes = _animeRepository.Find(parameters);
            //_animeRepository.Find
            return animes;
        }

        public async Task<GetAnimeResultDTO> GetAnimeById(Guid animeId)
        {
            var anime = _dbContext.Animes
                .Include(x => x.Titles)
                .Include(x => x.Synopsises)
                .Include(x => x.Posters)
                .FirstOrDefault(a => a.Id == animeId);

            var response = anime.Adapt<GetAnimeResultDTO>();
            return response;
        }

        public async Task<SearchAnimeResultDTO> SearchAnimeByName(string query)
        {
            var tedt = _dbContext.Animes
                .Include(x => x.Titles)
                .Include(x => x.Synopsises)
                .Include(x => x.Posters)
                .Take(40)
                .ToList();



            var searchAnime = _dbContext.AnimeTitles
                .Include(i => i.Anime).ThenInclude(x => x.Titles)
                .Include(i => i.Anime).ThenInclude(x => x.Synopsises)
                .Include(i => i.Anime).ThenInclude(x => x.Posters)
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

        private void MapConfigurate()
        {
            //TEMP Need delete

            TypeAdapterConfig<AnimeEntity, GetAnimeResultDTO>.NewConfig()
            .Map(
                dest => dest.PrimaryTitle,
                src => src.Titles.FirstOrDefault(x => x.IsOriginal == true).Body)
            .IgnoreIf((src, dest) => src.Synopsises.IsNullOrEmpty(), src => src.PrimarySynopsis)
            .Map(
               dest => dest.PrimarySynopsis,
               src => src.Synopsises.First().Body
            )
            .IgnoreIf((src, dest) => src.Posters.IsNullOrEmpty(), src => src.Poster.Original);
            /*.Map(
            dest => dest.Poster.Original,
            src => src.Posters.FirstOrDefault(x => x.Original);*/

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
