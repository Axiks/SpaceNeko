using Microsoft.EntityFrameworkCore;
using NekoSpace.API.General;
using NekoSpace.Core.Contracts.Models.ProvidingTranslationOfferService;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Data.Contracts.Enums;
using System.Security.Claims;

namespace NekoSpace.Core.Services.AnimeService
{
    public class ProvidingTranslationOffer
    {
        private Guid _userId;
        private ClaimsPrincipal _claimsPrincipal;
        private ApplicationDbContext _dbContext;

        public ProvidingTranslationOffer(ClaimsPrincipal claimsPrincipal, ApplicationDbContext context)
        {
            _dbContext = context;
            _claimsPrincipal = claimsPrincipal;
            string userGuid = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            _userId = Guid.Parse(userGuid);
        }

        public async Task<ProvidingTranslationOffertResponse> CreateOffer(ProvidingTranslationOfferInput providingTranslationOfferInput)
        {
            var animeItem = _dbContext.Animes.Include(x => x.Titles).FirstOrDefault(item => item.Id == providingTranslationOfferInput.AnimeId);

            AnimeTitleEntity title = new AnimeTitleEntity();
            if (animeItem != null)
            {
                title = NewTitleVariantModel(providingTranslationOfferInput);
            }
            else return new ProvidingTranslationOffertResponse(false, "No work found");

            if (IsUserHasAutomaticAcceptPermission() && IsFirstTitleLanguageProposition(providingTranslationOfferInput.AnimeId, providingTranslationOfferInput.Language))
            {
                title.IsMain = true;
            }

            animeItem.Titles.Add(title);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new ProvidingTranslationOffertResponse(true, null);
            }

            return new ProvidingTranslationOffertResponse(false, "Save failure");
        }

        private AnimeTitleEntity NewTitleVariantModel(ProvidingTranslationOfferInput providingTranslationOfferInput)
        {
            AnimeTitleEntity title = new AnimeTitleEntity();
            title.AnimeId = providingTranslationOfferInput.AnimeId;
            title.Body = providingTranslationOfferInput.PropositionBody;
            title.CreatorUserId = _userId;
            title.IsMain = false; //
            title.IsOriginal = false; // Визначається тільки ситемою
            title.IsAcceptProposal = null; //
            title.Language = providingTranslationOfferInput.Language;
            title.From = ItemFrom.User;

            return title;
        }

        private bool IsUserHasAutomaticAcceptPermission()
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
        }
    }
}
