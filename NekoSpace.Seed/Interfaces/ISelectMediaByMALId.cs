using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaByMALId<T> where T : Media
    {
        public RTO<T> GetByMALId(long Id);
    }
}
