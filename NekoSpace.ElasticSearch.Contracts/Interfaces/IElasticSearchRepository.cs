using NekoSpace.ElasticSearch.Contracts;
using NekoSpace.ElasticSearch.Contracts.General;
using Nest;

namespace NekoSpace.ElasticSearch.Contracts.Interfaces
{
    public interface IElasticSearchRepository<E,S> where E : ElasticSearchModelBasic where S : ElasticSearchMediaQueryParameters
    {
        public Task AddAsync(E mediaModel);
        public Task AddManyAsync(ICollection<E> mediaModels);
        public Task UpdateAsync(Guid Id, E mediaModel);
        public Task RemoveAsync(E media);
        public Task RemoveRangeAsync(List<E> mediaList);
        public Task<ISearchResponse<E>> SearchAsync(S parameters);
    }
}
