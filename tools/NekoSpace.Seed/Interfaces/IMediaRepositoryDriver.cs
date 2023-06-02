using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Models;
using NekoSpace.Seed.Models.DriverConfig;

namespace NekoSpace.Seed.Interfaces
{
    public interface IMediaRepositoryDriver<T> where T : MediaEntity
    {
        public List<RepositoryPackage<T>> GetAllRepositoriesPackage { get; }
        public void AddRepositoryPackage(RepositoryPackage<T> repository);
        public void DeleteRepositoryPackage(int index);
        public void RunSeed();
        public void RunUpdate();
    }
}
