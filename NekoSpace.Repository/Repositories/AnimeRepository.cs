using Mapster;
using MapsterMapper;
using NekoSpace.API.Contracts.Abstract;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.API.Contracts.Models.Media;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.Repository.Repositories
{
    public class AnimeRepository : AbstractMediaRepository<AnimeEntity, ElasticSearchAnimeModel, ElasticSearchAnimeQueryParameters>
    {
        private IMapper _mapper;
        private Language _primaryLang;
        private Language _secondaryLang;
        public AnimeRepository(ApplicationDbContext dbcontext, IElasticSearchRepository<ElasticSearchAnimeModel, ElasticSearchAnimeQueryParameters> esrepository, IMapper mapper) : base(dbcontext, esrepository, mapper)
        {
            _mapper = mapper;
            _primaryLang = Language.EN;
            _secondaryLang = Language.UK;
        }

        public ResponseMedia Find(GetAnimeQueryParameters parameters)
        {
            var result = new List<GetAnimeResultDTO>();
            //Мапимо питання в об'єкт зрозумілий ES
            // GetAnimeQueryParameters => ElasticSearchQueryParameters (Мало би працювати)
            ElasticSearchAnimeQueryParameters elasticSearchQueryParameters = _mapper.Map<ElasticSearchAnimeQueryParameters>(parameters); //Перевіряємо чи усе мапиться правильно

            // Спочатку шукаємо в ES
            var esObj = this.FindInElasticSearch(elasticSearchQueryParameters);
            var esResult = esObj.Documents;


            // Отримуємо і вносимо оцінки

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
                    r.CreatedAt
                },
                includeProperties: i => i.Posters
             );


            // Тут, через маппер, добавляємо бракуючі поля

            foreach (var animeDTO in getAnimeResultDTOs)
            {
                var media = dataFromDb.FirstOrDefault(x => x.Id == animeDTO.Id);

                var posters = media.Posters;
                var primaryPoster = posters.FirstOrDefault(x => x.Language == _primaryLang && x.IsMain == true);
                var secondaryPoster = posters.FirstOrDefault(x => x.Language == _secondaryLang && x.IsMain == true);

                animeDTO.PrimaryPoster = primaryPoster.Adapt<Poster>();
                animeDTO.SecondaryPoster = secondaryPoster.Adapt<Poster>();

                var createdAt = media.CreatedAt;

                animeDTO.CreatedAt = createdAt;

                result.Add(animeDTO);
            }

            var resultDTO = new ResponseMedia
            {
                TotalHits = esObj.Total,
                Result = result.Cast<BaseMediaResultDTO>().ToList()
            };

            return resultDTO;
        }
    }
}
