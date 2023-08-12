using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Interfaces
{
    public interface IElasticSearchSynchronizedService<T> where T : ElasticSearchModelBasic
    {
        public Task AddAsync(T mediaModel);
        public Task AddManyAsync(ICollection<T> mediaModels);
        public Task UpdateAsync(Guid Id, T mediaModel);
        public Task RemoveAsync(T media);
        public Task SearchAsync(ElasticSearchAnimeQueryParameters parameters);
    }
}
