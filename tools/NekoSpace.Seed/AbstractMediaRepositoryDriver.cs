using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts;
using NekoSpace.Repository.Contracts.Models;
using NekoSpace.Repository.Repositories.Media;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.Seed
{
    public partial class AbstractMediaRepositoryDriver<T, E> : IMediaRepositoryDriver<T> where T : MediaEntity where E : ElasticSearchMediaBasicModel
    {
        private List<RepositoryPackage<T>> _repositoriesPackage;
        private AbstractMediaRepository<T, E> _coreMediaRepository;
        private IMapper _mapper;

        public AbstractMediaRepositoryDriver(List<RepositoryPackage<T>> repositoriesPackage, AbstractMediaRepository<T, E> abstractMediaRepository, IMapper mapper)
        {

            _repositoriesPackage = repositoriesPackage;
            _coreMediaRepository = abstractMediaRepository;
            _mapper = mapper;
        }

        public List<RepositoryPackage<T>> GetAllRepositoriesPackage => throw new NotImplementedException();

        public void AddRepositoryPackage(RepositoryPackage<T> repository)
        {
            _repositoriesPackage.Add(repository);
        }

        public void DeleteRepositoryPackage(int index)
        {
            _repositoriesPackage.RemoveAt(index);
        }

        public void RunSeed()
        {
            Type[] interfaces = GetPrimaryRepository().GetType().GetInterfaces();

            if (interfaces.Contains(typeof(ISelectMediaAll<T>)))
            {
                ISelectMediaAll<T> primaryRepository = (ISelectMediaAll<T>)GetPrimaryRepository();
                SeedAllItem(primaryRepository);
            }
            else if (interfaces.Contains(typeof(ISelectMediaById<T>)))
            {
                ISelectMediaById<T> GetByIdFuncRepo = (ISelectMediaById<T>)GetPrimaryRepository();
                // Load ID. Тут мав би бути механізм зіставлення ID шок
                // Отримуємо назву сервісу з яким працює даний окнкретний плагін репозиторію
                //string serviceName = GetByIdFuncRepo.WorkWithServiceName;

                string serviceName = GetPrimaryRepository().WorkWithServiceName;
                // Тепер отриуємо усі поєднання DBId-serviceName
                var InterconnectionList = _coreMediaRepository.GetInterconnectionFromService(serviceName);

                var IDList = new List<String>();
                foreach(var interconnection in InterconnectionList)
                {
                    foreach(var link in interconnection.Value)
                    {
                        IDList.Add(link.Id);
                    }
                }

                SeedAllItemByIdList(GetByIdFuncRepo, IDList); // Грузимо сбди пов'язання
            }
        }

        private IRepository<T> GetPrimaryRepository()
        {
            return _repositoriesPackage
                .Where(x => x.IsInitial == true)
                .Select(x => x.repository).First();
        }

        private void SeedAllItem(ISelectMediaAll<T> repository)
        {
            var RTORepoData = repository.GetAll();
            /*            var RTORepoData = repository.GetAll().Skip(10000).Take(5000);
            */
            /*var data = RTORepoData.First().contain;
            _tableContext.Add(data);*/

            List<T> mediaEntityList = new List<T>();

            foreach (var item in RTORepoData)
            {
                T mediaItem = item.contain; //Ось це можемо впихувати в базу даних

                //Тут ми вносимо зв'язок між ID бази даних, і ID з інших сервісів
                /*var mediaAssociatedServices = mediaItem.AssociatedService;

                foreach (var serviceLink in mediaAssociatedServices)
                {
                    InterconnectionLink link = new InterconnectionLink
                    {
                        ServiceName = serviceLink.ServiceName.ToString(),
                        Id = serviceLink.ServiceId
                    };
                    _interconnectionMediaLink.AddLink(mediaItem.Id, link);
                }*/

                // Навішо нам це??


                mediaEntityList.Add(mediaItem);

            }

            _coreMediaRepository.AddRange(mediaEntityList);//??
            /*var x = _tableContext;

            var b = _tableContext.Select(x => x.Id).Count();

            var a1 = _dbContext.ChangeTracker.HasChanges();*/
            /*var a2 = _dbContext.ChangeTracker.Entries()
                .Any(e => e.State == EntityState.Added
                             || e.State == EntityState.Deleted
                             || e.State == EntityState.Modified);*/
            /*try
            {
                int c = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/



        }

        private void SeedAllItemByIdList(ISelectMediaById<T> repository, List<string> IdList)
        {
            foreach (string mediaId in IdList)
            {
                var RTO = repository.GetById(mediaId);
                if (RTO != null)
                {
                    _coreMediaRepository.Add(RTO.contain);//??
                }
            }
        }

        public void RunUpdate()
        {
            Type[] interfaces = GetPrimaryRepository().GetType().GetInterfaces();

            if (interfaces.Contains(typeof(ISelectMediaAll<T>)))
            {
                ISelectMediaAll<T> primaryRepository = (ISelectMediaAll<T>)GetPrimaryRepository();
                //SeedAllItem(primaryRepository);
            }
            else if (interfaces.Contains(typeof(ISelectMediaById<T>)))
            {
                ISelectMediaById<T> GetByIdFuncRepo = (ISelectMediaById<T>)GetPrimaryRepository();

                throw new NotImplementedException();
            }
        }



        private void UpdateAllItem(ISelectMediaAll<T> repository)
        {
            var RTORepoData = repository.GetAll();

            List<T> mediaEntityListToUpdate = new List<T>();

            foreach (var item in RTORepoData)
            {
                // Зіставляємо ID реплзиторія х DBId
                var links = item.contain.AssociatedService;
                var mapLinks = _mapper.Map<List<InterconnectionLinkModel>>(links);

                var Id = _coreMediaRepository.FindMediaIdByAnotherServiceList(mapLinks);
                if (Id == null) continue;
                //var mediaEntity = _coreMediaRepository.FindInDb(x => x.Id == Id);

                // Пеервіряємо чи одинокові значення, якщо ні => змінюємо



                T mediaItem = item.contain; //Ось це можемо впихувати в базу даних
                //_coreMediaRepository.Find(x => x.AssociatedService.Contains())
                // Перевіряємо на співпадіння

            }

            //_coreMediaRepository.AddRange(mediaEntityList);//??
        }
    }
}
