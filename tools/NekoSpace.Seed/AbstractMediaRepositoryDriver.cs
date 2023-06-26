using Microsoft.EntityFrameworkCore;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;

namespace NekoSpace.Seed
{
    public class AbstractMediaRepositoryDriver<T> : IMediaRepositoryDriver<T> where T : MediaEntity
    {
        private ApplicationDbContext _dbContext;
        private DbSet<T> _tableContext;
        private InterconnectionMediaLink _interconnectionMediaLink;
        private List<RepositoryPackage<T>> _repositoriesPackage;

        public AbstractMediaRepositoryDriver(ApplicationDbContext dbContext, List<RepositoryPackage<T>> repositoriesPackage)
        {
            _dbContext = dbContext;
            //_tableContext = tableContext;
            _tableContext = _dbContext.Set<T>();
            _interconnectionMediaLink = new InterconnectionMediaLink(new Dictionary<Guid, List<InterconnectionLink>>());
            _repositoriesPackage = repositoriesPackage;
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

        public DbSet<T> RunSeed()
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
                var IDList = _interconnectionMediaLink.GetAllIdFromService(serviceName);
                SeedAllItemByIdList(GetByIdFuncRepo, IDList); // Грузимо сбди пов'язання
            }
            return _tableContext;
        }

        private IRepository<T> GetPrimaryRepository()
        {
            return _repositoriesPackage
                .Where(x => x.repositoryConfiguration.IsInitial == true)
                .Select(x => x.repository).First();
        }

        private void SeedAllItem(ISelectMediaAll<T> repository)
        {
            var RTORepoData = repository.GetAll();

            var data = RTORepoData.First().contain;
            _tableContext.Add(data);

            /*foreach (var item in RTORepoData)
            {
                T mediaItem = item.contain; //Ось це можемо впихувати в базу даних

                //Тут ми вносимо зв'язок між ID бази даних, і ID з інших сервісів
                var mediaAssociatedServices =  mediaItem.AnotherService;

                foreach (var serviceLink in mediaAssociatedServices)
                {
                    InterconnectionLink link = new InterconnectionLink { 
                        ServiceName = serviceLink.ServiceName.ToString(),
                        Id = serviceLink.ServiceId
                    };
                    _interconnectionMediaLink.AddLink(mediaItem.Id, link);
                }

                _tableContext.Add(mediaItem);//??
            }*/
            var x = _tableContext;

            var b = _tableContext.Select(x => x.Id).Count();

            var a1 = _dbContext.ChangeTracker.HasChanges();
            /*var a2 = _dbContext.ChangeTracker.Entries()
                .Any(e => e.State == EntityState.Added
                             || e.State == EntityState.Deleted
                             || e.State == EntityState.Modified);*/
            try
            {
                int c = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }



        }

        private void SeedAllItemByIdList(ISelectMediaById<T> repository, List<string> IdList)
        {
            foreach (string mediaId in IdList)
            {
                var RTO = repository.GetById(mediaId);
                if (RTO != null)
                {
                    _tableContext.Add(RTO.contain);//??
                }
            }
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
                if (!links.Contains(interconnectionLink)) links.Add(interconnectionLink);
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
}
