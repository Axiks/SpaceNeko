using NekoSpace.Data.Contracts.Entities.Base;
using System.Linq.Expressions;

namespace NekoSpace.Repository.Contracts.Interfaces;

public interface IMediaRepository<T> where T : MediaEntity
{
    public void Add(T mediaEntity);
    public void AddRange(List<T> mediaEntityCollection);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    public void Update(T mediaEntity);
    public void Remove(T mediaEntity);
    void RemoveRange(IEnumerable<T> mediaEntity);
}
