using Mapster;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Offer.Response;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Repository.Repositories;
using System.Security.Claims;

namespace NekoSpace.Core.Services.OfferService
{
    public abstract class BasicOfferService<T, R> where T : MediaEntity where R : MediaRepository
    {
        private ClaimsPrincipal _claimsPrincipal;
        private R _mediaRepository;

        public BasicOfferService(ClaimsPrincipal claimsPrincipal, R _mediaRepository)
        {
            //_dbContext = dbContext;
            _claimsPrincipal = claimsPrincipal;
        }
        public async Task<DeleteOfferResponseDTO> DeleteOffer(Guid offerId)
        {
            var offer = _mediaRepository.FindInDb(filter: x => x.Titles).

            var offer = _dbContext.MediaTitles
                .FirstOrDefault(x => x.Id == offerId);
            if (offer == null) return new DeleteOfferResponseDTO(null, new ProblemDetails { Title = "No offers found" });

            _dbContext.Remove(offer);
            _dbContext.SaveChangesAsync();

            return new DeleteOfferResponseDTO(new DeleteOfferResponse { Success = true }, null);
        }

        // Moderator controll
        public async Task<UpdateOfferResponseDTO> AcceptProposition(Guid offerId)
        {
            var offer = _dbContext.MediaTitles
                .FirstOrDefault(x => x.Id == offerId);
            if (offer == null) return new UpdateOfferResponseDTO(null, new ProblemDetails { Title = "No offers found" });

            if(offer.IsAcceptProposal == true) return new UpdateOfferResponseDTO(null, new ProblemDetails { Title = "The offer has already been accepted" });

            offer.IsAcceptProposal = true;
            _dbContext.SaveChangesAsync();

            // Need user func!!
            // Need description func!!!
            // Need add ES func!!!

            var offerResult = offer.Adapt<OfferBasicResultDTO>();

            return new UpdateOfferResponseDTO(offerResult, null);
        }

        public async Task<UpdateOfferResponseDTO> RejectProposition(Guid offerId)
        {
            var offer = _dbContext.MediaTitles
                .FirstOrDefault(x => x.Id == offerId);
            if (offer == null) return new UpdateOfferResponseDTO(null, new ProblemDetails { Title = "No offers found" });

            if (offer.IsAcceptProposal == false) return new UpdateOfferResponseDTO(null, new ProblemDetails { Title = "The offer has already been rejected" });

            offer.IsAcceptProposal = false;
            _dbContext.SaveChangesAsync();

            // Need user func!!
            // Need description func!!!
            // Need add ES func!!!

            var offerResult = offer.Adapt<OfferBasicResultDTO>();

            return new UpdateOfferResponseDTO(offerResult, null);
        }
    }
}
