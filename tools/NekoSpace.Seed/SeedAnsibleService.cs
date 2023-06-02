using Arch.EntityFrameworkCore;
using JikanDotNet;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Driver;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpace.Seed.Models.DriverConfig;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.Manga;
using System.Reflection;
using System.Windows.Input;
using AutoMapper;

namespace NekoSpace.Seed
{
    public class SeedAnsibleService
    {
        private List<ISelectMediaAll<AnimeEntity>> animeRepositoryList;
        private List<ISelectMediaAll<MangaEntity>> mangaRepositoryList;
        private List<ISelectMediaAll<CharacterEntity>> characterRepositoryList;

        public void ReristerAnimeRepository(ISelectMediaAll<AnimeEntity> animeEntity) => animeRepositoryList.Add(animeEntity);
        public void ReristerMangaRepository(ISelectMediaAll<MangaEntity> mangaEntity) => mangaRepositoryList.Add(mangaEntity);
        public void ReristerCharacterRepository(ISelectMediaAll<CharacterEntity> characterEntity) => characterRepositoryList.Add(characterEntity);
        public void AnimeDriver()
        {
            // Обираємо той що має бути init (перший у списку)
            var initRepo = animeRepositoryList.First();

            // Сідуємо з нього усі поля у БД


            // Далі переходимо до наступного модулю, і відповідно до пріоритетів, сідувати дані (поки не пройдемо по усіх модулях)
        }
        public void MangaDriver()
        {

        }
        public void CharacterDriver()
        {

        }

    }

    public class AnimeSeedDriver : IMediaRepositoryDriver<AnimeEntity>
    {
        private DbSet<AnimeEntity> _tableContext;
        private InterconnectionMediaLink _interconnectionMediaLink;
        private List<RepositoryPackage<AnimeEntity>> _repositoriesPackage;

        private IMapper _mapper; //Temp

        public AnimeSeedDriver(DbSet<AnimeEntity> tableContext, List<RepositoryPackage<AnimeEntity>> repositoriesPackage)
        {
            _tableContext = tableContext;
            _repositoriesPackage = repositoriesPackage;
            _interconnectionMediaLink = new InterconnectionMediaLink(new Dictionary<Guid, List<InterconnectionLink>>());

            _mapper = AutoMapperInit().CreateMapper();

            LoadInterconnectionMediaLinks(); //Підгружаємо таблицю зв'язків
        }

        public List<RepositoryPackage<AnimeEntity>> GetAllRepositoriesPackage => _repositoriesPackage;

        public void AddRepositoryPackage(RepositoryPackage<AnimeEntity> repository)
        {
            _repositoriesPackage.Add(repository);
        }

        public void DeleteRepositoryPackage(int index)
        {
            _repositoriesPackage.RemoveAt(index);
        }
        private IRepository<AnimeEntity> GetPrimaryRepository()
        {
            return _repositoriesPackage
                .Where(x => x.repositoryConfiguration.IsInitial == true)
                .Select(x => x.repository).First();
        }

        public void RunSeed()
        {
            Type[] interfaces = GetPrimaryRepository().GetType().GetInterfaces();

            foreach (Type iface in interfaces)
            {
                if (iface == typeof(ISelectMediaAll<AnimeEntity>))
                {
                    ISelectMediaAll<AnimeEntity> GetAllFuncRepo = (ISelectMediaAll<AnimeEntity>)GetPrimaryRepository();
                    GetAllItem(GetAllFuncRepo);
                }
                else if (iface == typeof(ISelectMediaById<AnimeEntity>))
                {
                    ISelectMediaById<AnimeEntity> GetByIdFuncRepo = (ISelectMediaById<AnimeEntity>)GetPrimaryRepository();
                    // Load ID. Тут мав би бути механізм зіставлення ID шок
                    // Отримуємо назву сервісу з яким працює даний окнкретний плагін репозиторію
                    string serviceName = GetByIdFuncRepo.WorkWithServiceName;
                    // Тепер отриуємо усі поєднання DBId-serviceName
                    var IDList = _interconnectionMediaLink.GetAllIdFromService(serviceName);
                    GetAllItemByIdList(GetByIdFuncRepo, IDList); // Грузимо сбди пов'язання
                }
            }
        }

        private void GetAllItem(ISelectMediaAll<AnimeEntity> repository)
        {
            var RTORepoData = repository.GetAll();

            foreach(var item in RTORepoData)
            {
                AnimeEntity animeItem = item.contain; //Ось це можемо впихувати в базу даних

                //Тут ми вносимо зв'язок між ID бази даних, і ID з інштх сервісів
                var animeLinks = animeItem.AnotherService;

                foreach (InterconnectionLink link in ConverAnimeLinkModelToList(animeLinks))
                {
                    _interconnectionMediaLink.AddLink(animeItem.Id, link);
                }

                _tableContext.Add(animeItem);
            }
        }

        private void GetAllItemByIdList(ISelectMediaById<AnimeEntity> repository, List<string> IdList)
        {
            foreach(string animeId in IdList)
            {
                var RTO = repository.GetById(animeId);
                if (RTO != null)
                {
                    _tableContext.Add(RTO.contain);
                }
            }
        }

        private void UpdateStorage()
        {
            /*foreach(var repoPack in _repositoriesPackage)
            {
                var repoFields = repoPack.repositoryConfiguration.PriorityFields;

                foreach (var repoField in repoFields)
                {
                    if(repoField.Value == 1)
                    {
                        // Знайти це поле у БД
                        // Шукаємо ІД цього рядка у БД
                        //var DbId = _interconnectionMediaLink.GetDBIdByLink()
                    }
                }
            }*/

            // Знаходимо плагін з необхідним інтерфейсом
            var avaibleRepoPackage = _repositoriesPackage.Where(x => x.repository.GetType().GetInterfaces().Contains(typeof(ISelectMediaById<AnimeEntity>)));

            // Ііціалізуємо ті плагіни

            foreach (var media in _tableContext)
            {
                var mediaId = media.Id;

                //Тепер шукаємо дані про це аніме в різгих репозиторіях
                foreach (var repoPack in avaibleRepoPackage)
                {
                    // Шукаємо ID в репозиторію, якому належить запис в DB
                    List<InterconnectionLink> curentMediaId = _interconnectionMediaLink.GetLinksByDBId(mediaId);
                    var repoId = curentMediaId.FirstOrDefault(x => x.ServiceName == repoPack.repositoryConfiguration.Name).Id;
                    if (repoId == null) continue;

                    //Отримауємо доступ до інтерфейсу репозиторію
                    ISelectMediaById<AnimeEntity> repo = (ISelectMediaById<AnimeEntity>)repoPack.repository;

                    // Підгрузили усі рядки що можна змінювати
                    var repoFields = repoPack.repositoryConfiguration.PriorityFields;
                    foreach (var repoField in repoFields)
                    {
                        if (repoField.Value == 1)
                        {
                            // Ось цей рядок ми модифікуємо в БД!!!
                            //_tableContext.Update()
                            //var repoMedia = repo.GetById(repoId);

                            // Маюудь використати мапинг
                        }
                    }
                }

            }
        }

        private void LoadInterconnectionMediaLinks()
        {
            var animesEntity = _tableContext.Select(x => new { x.Id, x.AnotherService }).ToList();

            foreach (var anime in animesEntity)
            {
                var links = ConverAnimeLinkModelToList(anime.AnotherService);
                foreach (var link in links)
                {
                    _interconnectionMediaLink.AddLink(anime.Id, link);
                }
            }
        }

        public List<InterconnectionLink> ConverAnimeLinkModelToList(AnotherAnimeServiceEntity anotherAnimeServiceEntity)
        {
            List<InterconnectionLink> interconnectionLinks = new List<InterconnectionLink>();

            if (anotherAnimeServiceEntity.MyAnimeList != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "MyAnimeList",
                    Id = anotherAnimeServiceEntity.MyAnimeList.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }
            else if (anotherAnimeServiceEntity.NotifyId != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "NotifyId",
                    Id = anotherAnimeServiceEntity.NotifyId.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }
            else if (anotherAnimeServiceEntity.KitsuId != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "KitsuId",
                    Id = anotherAnimeServiceEntity.KitsuId.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }
            else if (anotherAnimeServiceEntity.AnilistId != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "AnilistId",
                    Id = anotherAnimeServiceEntity.AnilistId.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }
            else if (anotherAnimeServiceEntity.AnimeDBId != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "AnimeDBId",
                    Id = anotherAnimeServiceEntity.AnimeDBId.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }
            else if (anotherAnimeServiceEntity.AnimePlanetId != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "AnimePlanetId",
                    Id = anotherAnimeServiceEntity.AnimePlanetId.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }
            else if (anotherAnimeServiceEntity.AniSearchId != null)
            {
                InterconnectionLink interconnectionLink = new InterconnectionLink()
                {
                    ServiceName = "AniSearchId",
                    Id = anotherAnimeServiceEntity.AniSearchId.ToString()
                };
                interconnectionLinks.Add(interconnectionLink);
            }

            return interconnectionLinks;
        }

        private MapperConfiguration AutoMapperInit()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnimeEntity, AnimeEntity>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null));
            });

            return config;
        }

        public void RunUpdate()
        {
            throw new NotImplementedException();
        }
    }

    public class InterconnectionMediaLink
    {
        private Dictionary<Guid, List<InterconnectionLink>> InterconnectionLinksDb;

        public InterconnectionMediaLink(Dictionary<Guid, List<InterconnectionLink>> interconnectionLinksDb)
        {
            InterconnectionLinksDb = interconnectionLinksDb;
        }

        public void AddLink(Guid mediaDbId, InterconnectionLink interconnectionLink)
        {
            bool HasKey = InterconnectionLinksDb.ContainsKey(mediaDbId);
            if (HasKey)
            {
                List<InterconnectionLink> links = InterconnectionLinksDb[mediaDbId];
                if(!links.Contains(interconnectionLink)) links.Add(interconnectionLink);
                InterconnectionLinksDb[mediaDbId] = links; //?
            }
            else
            {
                InterconnectionLinksDb.Add(mediaDbId, new List<InterconnectionLink> { interconnectionLink });
            }

        }

        public Guid GetDBIdByLink(InterconnectionLink interconnectionLink)
        {
            var myKey = InterconnectionLinksDb.FirstOrDefault(x => x.Value.Contains(interconnectionLink)).Key;
            return myKey;
        }

        public List<InterconnectionLink> GetLinksByDBId(Guid Id)
        {
            return InterconnectionLinksDb[Id];
        }

        public List<InterconnectionLink> GetLinksByLink(InterconnectionLink interconnectionLink)
        {
            var myValue = InterconnectionLinksDb.FirstOrDefault(x => x.Value.Contains(interconnectionLink)).Value;
            return myValue;
        }

        public List<string> GetAllIdFromService(string serviceName)
        {
            var myValue = InterconnectionLinksDb.SelectMany(x => x.Value.Where(n => n.ServiceName == serviceName).Select(o => o.Id)).ToList();
            return myValue;
        }

    }

    public class InterconnectionLink
    {
        public required string ServiceName { get; set; }
        public required string Id { get; set; }
    }

    // Helpers

}
