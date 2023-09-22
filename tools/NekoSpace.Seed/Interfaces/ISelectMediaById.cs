
using NekoSpace.Data.Contracts.Entities.Base;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaById<T> where T : MediaEntity
    {
       // public string WorkWithServiceName { get; }
        public RTO<T> GetById(string Id);
    }
}
