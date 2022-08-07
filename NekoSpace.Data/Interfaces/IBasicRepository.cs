using NekoSpaceList.Models.General;

namespace NekoSpace.Data.Interfaces
{
    public interface IBasicRepository<T> where T : class
    {
        IQueryable<T> GetAll(int limit = 10, int offset = 0);
        T GetByID(Guid mediaId);
        IQueryable<T> Find(int limit = 10, int offset = 0);
        void Insert(T media);
        void Delete(T media);
        void Update(T media);
        void Save();
    }
}
