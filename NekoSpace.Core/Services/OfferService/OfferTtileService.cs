using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Contracts.Models.Offer.Response;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;
using NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request;
using NekoSpace.Core.Services.AnimeService;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.General;
using NekoSpace.Data.Contracts.Enums;
using System.Security.Claims;

namespace NekoSpace.Core.Services.OfferService
{
    public class OfferTtileService<T> : BasicOfferService<T> where T : MediaEntity
    {
        private ClaimsPrincipal _claimsPrincipal;
        private ApplicationDbContext _dbContext;

        public OfferTtileService(ClaimsPrincipal claimsPrincipal, ApplicationDbContext dbContext) : base(claimsPrincipal, dbContext)
        {
            _claimsPrincipal = claimsPrincipal;
            _dbContext = dbContext;
        }

        public async Task<CreateTitleOfferResponseDTO> CreateOffer(TitleOfferRequest request)
        {
            var mediaEntity = _dbContext.Set<T>();

            var animeItem = mediaEntity
                .Include(x => x.Titles)
                .FirstOrDefault(item => item.Id == request.MediaId);

            MediaTitleEntity title = new MediaTitleEntity();
            if (animeItem != null)
            {
                title = new MediaTitleEntity {
                    Body = request.Name,
                    From = ItemFrom.User,
                    IsMain = false,
                };
            }
            else
            {
                return new CreateTitleOfferResponseDTO(null, new ProblemDetails { Title = "No media found" });
            }

            animeItem.Titles.Add(title);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var offerResult = title.Adapt<TitleOfferResponse>();
                return new CreateTitleOfferResponseDTO(offerResult, null);
            }

            return new CreateTitleOfferResponseDTO(null, new ProblemDetails { Title = "Save failure" });
        }

        public async Task<ProvidingTranslationOffertResultListDTO> GetOffers()
        {
            var mediaEntity = _dbContext.Set<T>();
            var allUsersProposition = mediaEntity
                .Include(x => x.Titles)
                .Where(x => x.Titles.Any(z => z.From == ItemFrom.User))
                .ToListAsync().Result;

            var result = allUsersProposition.Adapt<ProvidingTranslationOffertResultListDTO>();
            return result;
        }

        public async Task<UpdateOfferResponseDTO> UpdateOffer(TitleOfferRequest request)
        {
            var offer = _dbContext.MediaTitles
                .FirstOrDefault(x => x.Id == request.MediaId);//Fix
            if (offer == null) return new UpdateOfferResponseDTO(null, new ProblemDetails { Title = "Save failure" });

            offer.Language = request.Language;
            offer.Body = request.Name;

            _dbContext.SaveChanges();

            var offerResult = offer.Adapt<OfferBasicResultDTO>();
            return new UpdateOfferResponseDTO(offerResult, null);
        }
    }
}
