using NekoSpace.Data.Contracts.Entities.General.Abstract;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaAll<T> where T : Media
    {
        public IEnumerable<RTO<T>> GetAll();
    }
}
