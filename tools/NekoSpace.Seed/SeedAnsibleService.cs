using NekoSpace.Seed.Driver;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpace.Seed.Models.DriverConfig;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.Manga;
using NekoSpace.Data;
using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore;
using NekoSpace.ElasticSearch;
using MapsterMapper;
using NekoSpace.Repository.Repositories.Media;

namespace NekoSpace.Seed
{
    public class SeedAnsibleService : ISeedAnsibleService
    {
        private AbstractMediaRepositoryDriver<AnimeEntity, ElasticSearchAnimeModel> _animeRepositoryDriver;
        private IMapper _mapper;

        public SeedAnsibleService(AbstractMediaRepository<AnimeEntity, ElasticSearchAnimeModel> animeRepository, IMapper mapper)
        {
            _mapper = mapper;

            IRepository<AnimeEntity> mamiRepository = new MamiAnimeDriver();


            // Це є пакунок репозиторія, з його налаштуваннями
            RepositoryPackage<AnimeEntity> repositoryPackage = new RepositoryPackage<AnimeEntity>
            {
                repository = mamiRepository,
                Name = mamiRepository.WorkWithServiceName,
                IsInitial = true,
            };

            // Це уже сптсок пакунків
            var animeRepositoryPackages = new List<RepositoryPackage<AnimeEntity>> { repositoryPackage };

            // Лрайвер репозиторій
            _animeRepositoryDriver = new AbstractMediaRepositoryDriver<AnimeEntity, ElasticSearchAnimeModel>(animeRepositoryPackages, animeRepository, _mapper);
        }

        public void RunSeed()
        {
            _animeRepositoryDriver.RunSeed();
        }

        /*public void ReristerAnimeRepository(ISelectMediaAll<AnimeEntity> animeEntity) => animeRepositoryList.Add(animeEntity);
        public void ReristerMangaRepository(ISelectMediaAll<MangaEntity> mangaEntity) => mangaRepositoryList.Add(mangaEntity);
        public void ReristerCharacterRepository(ISelectMediaAll<CharacterEntity> characterEntity) => characterRepositoryList.Add(characterEntity);*/


    }

}
