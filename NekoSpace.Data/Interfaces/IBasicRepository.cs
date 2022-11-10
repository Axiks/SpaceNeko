
using System.Linq.Expressions;

namespace NekoSpace.Data.Interfaces
{
    public interface IBasicRepository<T> where T : class
    {
        IEnumerable<T> Get();
        
        /*IEnumerable<T> Get(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
            );*/

        T GetById(object id);
        void Insert(T media);
        void Delete(T mediaToDelete);
        void Update(T mediaToUpdate);
        void Save();
    }
}
