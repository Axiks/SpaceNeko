
using NekoSpace.Data.Contracts.Entities.Base;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaByMALId<T> where T : MediaEntity
    {
        public RTO<T> GetByMALId(long Id);
    }
}
