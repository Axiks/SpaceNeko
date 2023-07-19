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
using NekoSpace.Repository;

namespace NekoSpace.Seed
{
    public class SeedAnsibleService : ISeedAnsibleService
    {
        private AbstractMediaRepositoryDriver<AnimeEntity, ElasticSearchAnimeModel> _animeRepositoryDriver;
        //private AbstractMediaRepositoryDriver<MangaEntity> _mangaRepositoryDriver;
        //private AbstractMediaRepositoryDriver<CharacterEntity> _characterRepositoryDriver;
        private ApplicationDbContext _dbcontext;

        // IMyScopedService is injected into Invoke
        public SeedAnsibleService(ApplicationDbContext dbcontext, IMapper mapper, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            IRepository<AnimeEntity> mamiRepository = new MamiAnimeDriver();

            RepositoryPackage<AnimeEntity> repositoryPackage = new RepositoryPackage<AnimeEntity>
            {
                repository = mamiRepository,
                Name = mamiRepository.WorkWithServiceName,
                IsInitial = true,
                //repositoryConfiguration = mamiRepositoryConfiguration
            };

            //DbSet<AnimeEntity> animeModelContext = _dbcontext.Animes;
            List<RepositoryPackage<AnimeEntity>> animeRepositoryPackages = new List<RepositoryPackage<AnimeEntity>> { repositoryPackage };

            AbstractElasticSearchRepository<ElasticSearchAnimeModel> esrepository = new ElasticSearchAnimeRepository(configuration);

            var abstractMediaRepository = new AbstractMediaRepository<AnimeEntity, ElasticSearchAnimeModel>(dbcontext, esrepository, mapper);

            _animeRepositoryDriver = new AbstractMediaRepositoryDriver<AnimeEntity, ElasticSearchAnimeModel>(animeRepositoryPackages, abstractMediaRepository);
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
