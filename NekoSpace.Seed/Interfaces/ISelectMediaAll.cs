using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaAll<T> where T : IMedia
    {
        public IEnumerable<RTO<T>> GetAll();
    }
}
