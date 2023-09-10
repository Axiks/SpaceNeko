using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using Nest;
using System.Linq.Expressions;

namespace NekoSpace.Repository.Contracts.Interfaces;

public interface IMediaRepository<T, E> where T : MediaEntity where E : ElasticSearchMediaBasicModel
{
    public void Add(T mediaEntity);
    public void AddRange(List<T> mediaEntityCollection);
    public ISearchResponse<E> FindInElasticSearch(ElasticSearchQueryParameters elasticSearchQueryParameters);
    public IEnumerable<TDest> FindInDb<TDest>(
        Expression<Func<T, bool>> filter = null,
        Expression<Func<T, TDest>> select = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includeProperties);
    public void Update(T mediaEntity);
    public void Remove(T mediaEntity);
    void RemoveRange(IEnumerable<T> mediaEntity);
}
