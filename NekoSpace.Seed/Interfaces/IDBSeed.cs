using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public interface IDBSeed<T> where T : IMedia
    {
        public void RunSeedRoles();
        public void RunSeedUsers();
        public IEnumerable<T> RunSeed();
        public IEnumerable<T> Search();
    }
}
