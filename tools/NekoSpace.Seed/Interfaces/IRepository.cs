using NekoSpace.Data.Contracts.Entities.Base;

namespace NekoSpace.Seed.Interfaces
{
    public interface IRepository<T> where T : MediaEntity
    {
        public string Name { get; }
        //public List<string> GetAvailableFields();
    }
}
