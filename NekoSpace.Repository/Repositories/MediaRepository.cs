using Mapster;
using MapsterMapper;
using NekoSpace.API.Contracts.Abstract;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.Media;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.ElasticSearch;
using NekoSpace.ElasticSearch.Contracts.General;
using NekoSpace.ElasticSearch.Contracts.Interfaces;

namespace NekoSpace.Repository.Repositories
{
    public class MediaRepository : AbstractMediaRepository<MediaEntity, ElasticSearchMediaBasicModel, ElasticSearchMediaQueryParameters>
    {
        private IMapper _mapper;
        private Language _primaryLang;
        private Language _secondaryLang;
        public MediaRepository(ApplicationDbContext dbcontext, IElasticSearchRepository<ElasticSearchMediaBasicModel, ElasticSearchMediaQueryParameters> esrepository, IMapper mapper) : base(dbcontext, esrepository, mapper)
        {
        }

        public ResponseMedia Find(GetMediaQueryParameters parameters)
        {
            var result = new List<BaseMediaResultDTO>();
            //Мапимо питання в об'єкт зрозумілий ES
            // GetAnimeQueryParameters => ElasticSearchQueryParameters (Мало би працювати)
            ElasticSearchMediaQueryParameters elasticSearchQueryParameters = _mapper.Map<ElasticSearchMediaQueryParameters>(parameters); //Перевіряємо чи усе мапиться правильно

            // Спочатку шукаємо в ES
            var esObj = this.FindInElasticSearch(elasticSearchQueryParameters);
            var esResult = esObj.Documents;


            // Отримуємо і вносимо оцінки

            // Мапимо на об'єкт котрий вертатимо у фронт
            // ElasticSearchAnimeModel => ElasticSearchAnimeModel

            try
            {
                //  Block of code to try
                var test = _mapper.Map<List<BaseMediaResultDTO>>(esResult); //????
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                var es = e;
            }
            var getMediaResultDTOs = _mapper.Map<List<BaseMediaResultDTO>>(esResult); //????


            // Тут ми проходимся по кожному елементу, й отримуємо усі його ID
            var mediasId = new List<Guid>();
            foreach (var mediaDTO in getMediaResultDTOs)
            {
                mediasId.Add(mediaDTO.Id);
            }

            var dataFromDb = this.FindInDb(
                filter: x => mediasId.Contains(x.Id),
                select: r => new {
                    r.Id,
                    r.Posters,
                    r.CreatedAt
                },
                includeProperties: i => i.Posters
             );


            // Тут, через маппер, добавляємо бракуючі поля

            foreach (var mediaDTO in getMediaResultDTOs)
            {
                var media = dataFromDb.FirstOrDefault(x => x.Id == mediaDTO.Id);

                var posters = media.Posters;
                var primaryPoster = posters.FirstOrDefault(x => x.Language == _primaryLang && x.IsMain == true);
                var secondaryPoster = posters.FirstOrDefault(x => x.Language == _secondaryLang && x.IsMain == true);

                mediaDTO.PrimaryPoster = primaryPoster.Adapt<Poster>();
                mediaDTO.SecondaryPoster = secondaryPoster.Adapt<Poster>();

                var createdAt = media.CreatedAt;

                mediaDTO.CreatedAt = createdAt;

                result.Add(mediaDTO);
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
