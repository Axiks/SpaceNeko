using Mapster;
using Microsoft.Extensions.Configuration;
using NekoSpace.Data;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository.Contracts.Enums;
using NekoSpace.Repository.Repositories.Offer.Abstract;
using NekoSpaceList.Models.General;

namespace NekoSpace.Repository.Repositories.Offer
{
    public class TitleOfferRepository : ESOfferRepositoryProxy<TextVariantSubItemEntity>
    {
        private ElasticSearchMediaRepository _esMediaRepository;

        public TitleOfferRepository(ApplicationDbContext dbcontext, IConfiguration configuration, ESMediaTypeIndex indexName) : base(new OfferRepository<TextVariantSubItemEntity>(dbcontext))
        {
            _esMediaRepository = new ElasticSearchMediaRepository(indexName.ToString().Normalize().ToLower(), configuration);
        }

        private protected override async void AddOfferToES(TextVariantSubItemEntity offer)
        {
            // Перевіряємо чи такого саої пропозиції часом не існує
            var mediaItems = _esMediaRepository.GetByMediaIdAsync(offer.MediaId).Result;
            if (mediaItems.Documents.Count == 0) throw (new Exception("The offer does not exist"));

            // Первіряємо чи дійсно можемо добавити таке значення
            var mediaTitles = mediaItems.Documents.First().Titles;
            var isSameExist = mediaTitles.FirstOrDefault(x => x.Body == offer.Body && x.Language == offer.Language) != null;
            if(isSameExist) throw (new Exception("The same name is already in use"));

            // Отримуємо ID 
            //var esMediaId = mediaItems.Hits.First().Id;

            // Добавляємо значення в result
            var currentMedia = mediaItems.Documents.First();
            // Парсимо у потрібне значення
            var newTitle = offer.Adapt<ESMediaBasicTitleModel>();

            currentMedia.Titles.Add(newTitle);
            await _esMediaRepository.UpdateAsync(currentMedia);
        }

        private protected override async void DeleteOfferInES(TextVariantSubItemEntity offer)
        {
            // Перевіряємо чи такого саої пропозиції часом не існує
            var mediaItems = _esMediaRepository.GetByMediaIdAsync(offer.MediaId).Result;
            if (mediaItems.Documents.Count == 0) throw (new Exception("The offer does not exist"));

            // Перевіряємо чи дане значення існує
            var currentMedia = mediaItems.Documents.First();
            var mediaTitles = currentMedia.Titles;
            var title = mediaTitles.FirstOrDefault(x => x.Body == offer.Body && x.Language == offer.Language);
            if(title == null) throw (new Exception("This value does not exist"));

            // Видаляємо дане значення
            mediaTitles.Remove(title);
            // Отримуємо ID 
            //var esMediaId = mediaItems.Hits.First().Id;

            await _esMediaRepository.UpdateAsync(currentMedia);
        }

        private protected override async void UpdateOfferInES(TextVariantSubItemEntity offer)
        {
            // Перевіряємо чи такого саої пропозиції часом не існує
            var mediaItems = _esMediaRepository.GetByMediaIdAsync(offer.MediaId).Result;
            if (mediaItems.Documents.Count == 0) throw (new Exception("The offer does not exist"));

            // Перевіряємо чи дане значення існує
            var currentMedia = mediaItems.Documents.First();
            var mediaTitles = currentMedia.Titles;
            var title = mediaTitles.FirstOrDefault(x => x.Body == offer.Body && x.Language == offer.Language);
            if (title == null) throw (new Exception("This value does not exist"));

            // Оновлюємо значення
            title = offer.Adapt<ESMediaBasicTitleModel>();
            title.UpdatedAt = DateTime.Now;

            //var esMediaId = mediaItems.Hits.First().Id;
            await _esMediaRepository.UpdateAsync(currentMedia);
        }
    }
}
