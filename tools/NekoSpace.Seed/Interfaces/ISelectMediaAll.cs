
using NekoSpace.Data.Contracts.Entities.Base;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaAll<T> where T : MediaEntity
    {
        public IEnumerable<RTO<T>> GetAll();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    }
}
