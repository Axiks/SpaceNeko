using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface IDBSeed<T> where T : IMedia
    {
        public IEnumerable<T> RunSeed();
    }
}
