using Mapster;
using MapsterMapper;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Data;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpaceList.Models.Anime;
using System.Linq;

namespace NekoSpace.Repository.Repositories
{
    public class AnimeRepository : AbstractMediaRepository<AnimeEntity, ElasticSearchAnimeModel>
    {
        private IMapper _mapper;
        public AnimeRepository(ApplicationDbContext dbcontext, IElasticSearchRepository<ElasticSearchAnimeModel> esrepository, IMapper mapper) : base(dbcontext, esrepository, mapper)
        {
            _mapper = mapper;
        }

        public List<GetAnimeResultDTO> Find(GetAnimeQueryParameters parameters)
        {
            var result = new List<GetAnimeResultDTO>();
            //Мапимо питання в об'єкт зрозумілий ES
            // GetAnimeQueryParameters => ElasticSearchQueryParameters (Мало би працювати)
            ElasticSearchQueryParameters elasticSearchQueryParameters = _mapper.Map<ElasticSearchQueryParameters>(parameters); //Перевіряємо чи усе мапиться правильно
            
            // Спочатку шукаємо в ES
            var esResult = this.FindInElasticSearch(elasticSearchQueryParameters).Documents;

            // Мапимо на об'єкт котрий вертатимо у фронт
            // ElasticSearchAnimeModel => ElasticSearchAnimeModel
            
            try
            {
                //  Block of code to try
                var test = _mapper.Map<List<GetAnimeResultDTO>>(esResult); //????
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                var es = e;
            }
            var getAnimeResultDTOs = _mapper.Map<List<GetAnimeResultDTO>>(esResult); //????
            // Тут ми проходимся по кожному елементу, й отримуємо усі його ID
            var animesId = new List<Guid>();
            foreach (var animeDTO in getAnimeResultDTOs)
            {
                animesId.Add(animeDTO.Id);
            }

            var dataFromDb = this.FindInDb(
                filter: x => animesId.Contains(x.Id),
                select: r => new {
                    r.Id,
                    r.Posters,
                    r.UpdatedAt
                },
                includeProperties: i => i.Posters
                );

            // Тут, через маппер, добавляємо бракуючі поля

            foreach (var animeDTO in getAnimeResultDTOs)
            {
                var poster  = dataFromDb.FirstOrDefault(x => x.Id == animeDTO.Id).Posters.FirstOrDefault();
                animeDTO.Poster = poster.Adapt<Poster>();
                result.Add(animeDTO);
            }

            return result;
        }
    }
}
