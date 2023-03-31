using JikanDotNet;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;
using NekoSpace.API.General;
using NekoSpace.Core.Contracts.Models.ProvidingTranslationOfferService;
using NekoSpace.Core.Services.AnimeService;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.Manga;
using NekoSpace.Data.Contracts.Enums;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using System.Security.Claims;

namespace NekoSpace.Core.Services.OfferController
{
    public class OfferService
    {
        private Guid _userId;
        private ClaimsPrincipal _claimsPrincipal;
        private ApplicationDbContext _dbContext;

        public OfferService(ClaimsPrincipal claimsPrincipal, ApplicationDbContext context)
        {
            _dbContext = context;
            _claimsPrincipal = claimsPrincipal;
            string userGuid = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            _userId = Guid.Parse(userGuid);

            MapConfigurate();
        }

        public async Task<ProvidingTranslationOffertResultDTO> CreateOfferAnimeTitle(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            var animeItem = _dbContext.Animes.Include(x => x.Titles).FirstOrDefault(item => item.Id == animeId);

            AnimeTitleEntity title = new AnimeTitleEntity();
            if (animeItem != null)
            {
                title = NewAnimeTitleOfferModel(animeId, providingTranslationOfferInput);
            }
            else return new ProvidingTranslationOffertResultDTO(null, "No media found");

            /*if (IsUserHasAutomaticAcceptPermission() && IsFirstTitleLanguageProposition(animeId, providingTranslationOfferInput.Language))
            {
                title.IsMain = true;
            }*/

            animeItem.Titles.Add(title);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var offerResult = title.Adapt<OfferBasicResultDTO>();
                return new ProvidingTranslationOffertResultDTO(offerResult, null);
            }

            return new ProvidingTranslationOffertResultDTO(null, "Save failure");
        }

        public async Task<ProvidingTranslationOffertResultListDTO> GetOfferAnimeTitles()
        {
            var offerItem = await _dbContext.AnimeTitles.Where(x => x.From == ItemFrom.User).ToListAsync();
            var result = offerItem.Adapt<ProvidingTranslationOffertResultListDTO>();
            return result;
        }

        public async Task<ProvidingTranslationOffertResultDTO> GetOfferAnimeTitleById(Guid titleId)
        {
            var offerItem = await _dbContext.AnimeTitles.Where(x => x.Id == titleId).FirstOrDefaultAsync();
            var result = offerItem.Adapt<ProvidingTranslationOffertResultDTO>();
            return result;
        }

        public async Task<ProvidingTranslationOffertResultListDTO> GetOfferAnimeSynopsis()
        {
            var offerItem = await _dbContext.AnimeSynopsises.Where(x => x.From == ItemFrom.User).ToListAsync();
            var result = offerItem.Adapt<ProvidingTranslationOffertResultListDTO>();
            return result;
        }
        public async Task<ProvidingTranslationOffertResultDTO> GetOfferAnimeSynopsisById(Guid titleId)
        {
            var offerItem = await _dbContext.Animes.Where(x => x.Id == titleId).FirstOrDefaultAsync();
            var result = offerItem.Adapt<ProvidingTranslationOffertResultDTO>();
            return result;
        }

        public async Task<ProvidingTranslationOffertResultDTO> CreateOfferAnimeSynopsis(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            var animeItem = _dbContext.Animes.Include(x => x.Titles).FirstOrDefault(item => item.Id == animeId);

            AnimeSynopsisEntity synopsis = new AnimeSynopsisEntity();
            if (animeItem != null)
            {
                synopsis = NewAnimeSynopsisOfferModel(animeId, providingTranslationOfferInput);
            }
            else return new ProvidingTranslationOffertResultDTO(null, "No media found");

            animeItem.Synopsises.Add(synopsis);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var offerResult = synopsis.Adapt<OfferBasicResultDTO>();
                return new ProvidingTranslationOffertResultDTO(offerResult, null);
            }

            return new ProvidingTranslationOffertResultDTO(null, "Save failure");
        }

        private AnimeTitleEntity NewAnimeTitleOfferModel(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            AnimeTitleEntity title = new AnimeTitleEntity();
            title = (AnimeTitleEntity)NewTitleVariantModel(title, providingTranslationOfferInput);
            title.AnimeId = animeId;
            return title;
        }
        private AnimeSynopsisEntity NewAnimeSynopsisOfferModel(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            AnimeSynopsisEntity synopsis = new AnimeSynopsisEntity();
            synopsis = (AnimeSynopsisEntity)NewTitleVariantModel(synopsis, providingTranslationOfferInput);
            synopsis.AnimeId = animeId;
            return synopsis;
        }
        private MangaTitleEntity NewMangaTitleOfferModel(Guid mangaId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            MangaTitleEntity title = new MangaTitleEntity();
            title = (MangaTitleEntity)NewTitleVariantModel(title, providingTranslationOfferInput);
            title.MangaId = mangaId;
            return title;
        }
        private MangaSynopsisEntity NewMangaSynopsisOfferModel(Guid mangaId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            MangaSynopsisEntity synopsis = new MangaSynopsisEntity();
            synopsis = (MangaSynopsisEntity)NewTitleVariantModel(synopsis, providingTranslationOfferInput);
            synopsis.MangaId = mangaId;
            return synopsis;
        }

        private TextVariantSubItemEntity NewTitleVariantModel(TextVariantSubItemEntity title, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            title.Body = providingTranslationOfferInput.PropositionBody;
            title.CreatorUserId = _userId;
            title.IsMain = false; // ВИзначатиметься після рішення
            title.IsOriginal = false; //Only System
            title.IsAcceptProposal = null; // 
            title.Language = providingTranslationOfferInput.Language;
            title.From = ItemFrom.User;

            return title;
        }

/*        private bool IsUserHasAutomaticAcceptPermission()
        {
            if (_claimsPrincipal.IsInRole(Roles.AdministratorRole) || _claimsPrincipal.IsInRole(Roles.ModeratorRole) || _claimsPrincipal.IsInRole(Roles.CreatorRole))
            {
                return true;
            }
            return false;
        }

        private bool IsFirstTitleLanguageProposition(Guid animeId, Language language)
        {
            var query = from p in _dbContext.AnimeTitles
                        where p.AnimeId == animeId && p.Language == language && p.IsMain == true
                        select new
                        {
                            p.Id
                        };
            var countElements = query.Count();
            if (countElements == 0)
            {
                return true;
            }
            return false;
        }*/

        private void MapConfigurate()
        {
            TypeAdapterConfig<AnimeTitleEntity, OfferBasicResultDTO>.NewConfig()
            .Map(
                dest => dest.Language,
                src => src.Language.ToString());

            TypeAdapterConfig<List<AnimeTitleEntity>, ProvidingTranslationOffertResultListDTO>.NewConfig()
            .Map(
                dest => dest.Result,
                src => src);
        }
    }
}
