﻿using NekoSpace.ElasticSearch.Contracts;
using Nest;

namespace NekoSpace.ElasticSearch.Contracts.Interfaces
{
    public interface IElasticSearchRepository<T> where T : ElasticSearchModelBasic
    {
        public Task AddAsync(T mediaModel);
        public Task AddManyAsync(ICollection<T> mediaModels);
        public Task UpdateAsync(T mediaModel);
        public Task RemoveAsync(T media);
        public Task RemoveRangeAsync(List<T> mediaList);
        public Task<ISearchResponse<T>> SearchAsync(ElasticSearchQueryParameters parameters);
    }
}
