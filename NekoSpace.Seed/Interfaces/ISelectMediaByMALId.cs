using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface ISelectMediaByMALId<T> where T : IMedia
    {
        public RTO<T> GetByMALId(long Id);
    }
}
