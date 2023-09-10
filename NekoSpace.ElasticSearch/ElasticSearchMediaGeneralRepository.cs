using Microsoft.Extensions.Configuration;
using NekoSpace.Repository.Contracts.Enums;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchMediaGeneralRepository : ElasticSearchMediaRepository
    {
        public ElasticSearchMediaGeneralRepository(IConfiguration configuration) : base(ESMediaTypeIndex.animeIndex.ToString() + "," + ESMediaTypeIndex.mangaIndex.ToString()
, configuration)
        {
        }
    }
}
