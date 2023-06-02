using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models.DriverConfig;

namespace NekoSpace.Seed.Models
{
    public abstract class RepositoryPackage<T> where T : MediaEntity
    {
        public IRepository<T> repository { get; set; }
        public RepositoryConfiguration repositoryConfiguration { get; set; }
    }
}
