using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed.Models.DriverConfig;

namespace NekoSpace.Seed.Models
{
    public class RepositoryPackage<T> where T : MediaEntity
    {
        public required IRepository<T> repository { get; set; }
        public required RepositoryConfiguration repositoryConfiguration { get; set; }
    }
}
