using Arch.EntityFrameworkCore;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.Seed
{
    public abstract class AbstractRepositoryDriver<T> : IMediaRepositoryDriver<T> where T : MediaEntity
    {
        private DbSet<T> _tableContext;
        private InterconnectionMediaLink _interconnectionMediaLink;
        private List<RepositoryPackage<T>> _repositoriesPackage;

        protected AbstractRepositoryDriver(DbSet<T> tableContext, InterconnectionMediaLink interconnectionMediaLink, List<RepositoryPackage<T>> repositoriesPackage)
        {
            _tableContext = tableContext;
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

        public void RunSeed()
        {
            Type[] interfaces = GetPrimaryRepository().GetType().GetInterfaces();

            foreach (Type iface in interfaces)
            {
                if (iface == typeof(ISelectMediaAll<T>))
                {
                    ISelectMediaAll<T> GetAllFuncRepo = (ISelectMediaAll<T>)GetPrimaryRepository();
                    GetAllItem(GetAllFuncRepo);
                }
                else if (iface == typeof(ISelectMediaById<T>))
                {
                    ISelectMediaById<T> GetByIdFuncRepo = (ISelectMediaById<T>)GetPrimaryRepository();
                    // Load ID. Тут мав би бути механізм зіставлення ID шок
                    // Отримуємо назву сервісу з яким працює даний окнкретний плагін репозиторію
                    string serviceName = GetByIdFuncRepo.WorkWithServiceName;
                    // Тепер отриуємо усі поєднання DBId-serviceName
                    var IDList = _interconnectionMediaLink.GetAllIdFromService(serviceName);
                    GetAllItemByIdList(GetByIdFuncRepo, IDList); // Грузимо сбди пов'язання
                }
            }
        }

        private IRepository<T> GetPrimaryRepository()
        {
            return _repositoriesPackage
                .Where(x => x.repositoryConfiguration.IsInitial == true)
                .Select(x => x.repository).First();
        }

        private void GetAllItem(ISelectMediaAll<T> repository)
        {
            var RTORepoData = repository.GetAll();

            foreach (var item in RTORepoData)
            {
                T animeItem = item.contain; //Ось це можемо впихувати в базу даних

                //Тут ми вносимо зв'язок між ID бази даних, і ID з інштх сервісів
                var animeLinks = animeItem.AnotherService; // Це переробити на окрему таблицю

                foreach (InterconnectionLink link in ConverAnimeLinkModelToList(animeLinks))
                {
                    _interconnectionMediaLink.AddLink(animeItem.Id, link);
                }

                _tableContext.Add(animeItem);//??
            }
        }

        private void GetAllItemByIdList(ISelectMediaById<T> repository, List<string> IdList)
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
}
