using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Contracts.Models.Offer.Request.Decision;
using NekoSpace.API.Contracts.Models.Offer.Request.Get;
using NekoSpace.API.Contracts.Models.Offer.Request.Update;
using NekoSpace.API.Contracts.Models.Offer.Response;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;
using NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request;
using NekoSpace.Common.Enums.API;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.General.Media;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository.Contracts.Enums;
using NekoSpace.Repository.Repositories.Media;
using NekoSpace.Repository.Repositories.Offer;
using NekoSpace.Repository.Repositories.Offer.Abstract;
using NekoSpaceList.Models.General;
using System.Security.Claims;

namespace NekoSpace.Core.Services.OfferController
{
    public class OfferService
    {
        private readonly Guid _userId;
        private readonly List<Claim> _userRoles;
        private ClaimsPrincipal _claimsPrincipal;
        private ApplicationDbContext _dbContext;
        private AbstractMediaRepository<MediaEntity, ElasticSearchMediaBasicModel> _mediaRepository;
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        //private TitleOfferRepository _titleOfferRepository;

        public OfferService(ClaimsPrincipal claimsPrincipal, ApplicationDbContext context, AbstractMediaRepository<MediaEntity, ElasticSearchMediaBasicModel> mediaRepository, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = context;
            _claimsPrincipal = claimsPrincipal;
            string userGuid = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            _userRoles = claimsPrincipal.FindAll(ClaimTypes.Role).ToList();
            _userId = Guid.Parse(userGuid);
            _mediaRepository = mediaRepository;
            _configuration = configuration;
            _mapper = mapper;

            //MapConfigurate();
        }

        public async Task<CreateTitleOfferResponseDTO> CreateTitleOffer(TitleOfferRequest offerRequest)
        {
            // Check existence Media
            var mediaResult = _mediaRepository.FindInDb(
                filter: x => x.Id == offerRequest.MediaId,
                select: (
                    x => x.Titles
                ),
                includeProperties: x => x.Titles
                );
            if (mediaResult == null || mediaResult.Count() == 0) return new CreateTitleOfferResponseDTO(null, new ProblemDetails { Title = "No media found" });

            // Get User
            //var user = _dbContext.Users.FirstOrDefaultAsync(x => x.Id == _userId.ToString()).Result;

            // Create offer
            var offerTextVariant = new MediaTitleEntity();
            offerTextVariant.Body = offerRequest.Name;
            offerTextVariant.Language = offerRequest.Language;
            offerTextVariant.CreatorUserId = _userId.ToString();
            offerTextVariant.MediaId = offerRequest.MediaId;
            offerTextVariant.From = ItemFrom.User;
            offerTextVariant.IsMain = false;

            var titleOfferRepository = new TitleOfferRepository(_dbContext, _configuration, ESMediaTypeIndex.animeIndex); // FIX!

            TextVariantSubItemEntity createResult = titleOfferRepository.CreateOffer(offerTextVariant).Result;
            var offerResult = _mapper.Map<TitleOfferResponse>(createResult);
            return new CreateTitleOfferResponseDTO(offerResult, null);
        }

        public async Task<CreateTitleOfferResponseDTO> UpdateTitleOffer(UpdateTitleOfferRequest offerRequest)
        {
            // Check existence Proposition
            var offer = _dbContext.MediaTitles.FirstOrDefaultAsync(x => x.Id == offerRequest.OfferId).Result;
            if (offer == null) return new CreateTitleOfferResponseDTO(null, new ProblemDetails { Title = "Offer does not exist" });

            // Proposition accept or no accept??
            bool isModerator = _claimsPrincipal.IsInRole(Role.Administrator.ToString()) || _claimsPrincipal.IsInRole(Role.Moderator.ToString());

            if(!isUserCanChange(offer)) return new CreateTitleOfferResponseDTO(null, new ProblemDetails { Title = "You cannot change offer" });

            // Update offer
            var offerTextVariant = new MediaTitleEntity();
            offerTextVariant.Body = offerRequest.Name;
            offerTextVariant.Language = offerRequest.Language;

            var hasError = ModeratorFunc(offerRequest, offerTextVariant); // Moderator user can change this
            if (hasError != null) return new CreateTitleOfferResponseDTO(null, hasError);

            var titleOfferRepository = new TitleOfferRepository(_dbContext, _configuration, ESMediaTypeIndex.animeIndex); // FIX!

            TextVariantSubItemEntity createResult = titleOfferRepository.UpdateOffer(offerTextVariant).Result;
            var offerResult = _mapper.Map<TitleOfferResponse>(createResult);
            return new CreateTitleOfferResponseDTO(offerResult, null);
        }

        public async Task<CreateDescriptionOfferResponseDTO> CreateSynopsisOffer(DescriptionOfferRequest offerRequest)
        {
            // Check existence Media
            var mediaResult = _mediaRepository.FindInDb(
                filter: x => x.Id == offerRequest.MediaId,
                select: (
                    x => x.Synopsises
                ),
                includeProperties: x => x.Synopsises
                );
            if (mediaResult == null || mediaResult.Count() == 0) return new CreateDescriptionOfferResponseDTO(null, new ProblemDetails { Title = "No media found" });

            // Get User
            //var user = _dbContext.Users.FirstOrDefaultAsync(x => x.Id == _userId.ToString()).Result;

            // Create offer
            var offerTextVariant = new MediaSynopsisEntity();
            offerTextVariant.Body = offerRequest.Description;
            offerTextVariant.Language = offerRequest.Language;
            offerTextVariant.CreatorUserId = _userId.ToString();
            offerTextVariant.MediaId = offerRequest.MediaId;
            offerTextVariant.From = ItemFrom.User;
            offerTextVariant.IsMain = false;

            var titleOfferRepository = new DescriptionOfferRepository(_dbContext);

            TextVariantSubItemEntity createResult = titleOfferRepository.CreateOffer(offerTextVariant).Result;
            var offerResult = _mapper.Map<DescriptionOfferResponse>(createResult);
            return new CreateDescriptionOfferResponseDTO(offerResult, null);
        }

        public async Task<CreateDescriptionOfferResponseDTO> UpdateSynopsisOffer(UpdateDescriptionOfferRequest offerRequest)
        {
            // Check existence Proposition
            var offer = _dbContext.MediaSynopsis.FirstOrDefaultAsync(x => x.Id == offerRequest.OfferId).Result;
            if (offer == null) return new CreateDescriptionOfferResponseDTO(null, new ProblemDetails { Title = "Offer does not exist" });

            if (!isUserCanChange(offer)) return new CreateDescriptionOfferResponseDTO(null, new ProblemDetails { Title = "You cannot change offer" });

            // Update offer
            offer.Body = offerRequest.Description;
            offer.Language = offerRequest.Language;

            var hasError = ModeratorFunc(offerRequest, offer); // Moderator user can change this
            if(hasError != null) return new CreateDescriptionOfferResponseDTO(null, hasError);

            var descriptionOfferRepository = new DescriptionOfferRepository(_dbContext);

            TextVariantSubItemEntity createResult = descriptionOfferRepository.UpdateOffer(offer).Result;
            var offerResult = _mapper.Map<DescriptionOfferResponse>(createResult);
            return new CreateDescriptionOfferResponseDTO(offerResult, null);
        }

        public async Task<DeleteOfferResponseDTO> DeleteOffer(Guid offerId)
        {
            // Check existence Proposition
            // NEED Fix!!!!
            TextVariantSubItemEntity offer;
            offer = _dbContext.MediaTitles.FirstOrDefaultAsync(x => x.Id == offerId).Result;
            if(offer == null) offer = _dbContext.MediaSynopsis.FirstOrDefaultAsync(x => x.Id == offerId).Result;

            if (!isUserCanChange(offer)) return new DeleteOfferResponseDTO(null, new ProblemDetails { Title = "You cannot change offer" });

            if (offer == null) return new DeleteOfferResponseDTO(null, new ProblemDetails { Title = "Offer does not exist" });

            var basicOfferRepository = new OfferRepository<RootVariantSubItemEntity>(_dbContext);
            basicOfferRepository.DeleteOffer(offer);

            return new DeleteOfferResponseDTO(new DeleteOfferResponse { Success = true }, null);
        }

        public async Task<GetBasicOfferResponseDTO<BasicOfferResponse>> GetOffer(Guid offerId)
        {
            // Маємо знайти пропозицію за ID, і підгрузити про них повну інформацію
            TextVariantSubItemEntity offer = _dbContext.MediaTitles.FirstOrDefaultAsync(x => x.Id == offerId).Result;
            if(offer != null)
            {
                TitleOfferResponse titleOfferResponse = _mapper.Map<TitleOfferResponse>(offer);
                return new GetBasicOfferResponseDTO<BasicOfferResponse>(titleOfferResponse, null);
            }

            offer = _dbContext.MediaSynopsis.FirstOrDefaultAsync(x => x.Id == offerId).Result;
            if (offer != null)
            {
                DescriptionOfferResponse synopsisOfferResponse = _mapper.Map<DescriptionOfferResponse>(offer);
                return new GetBasicOfferResponseDTO<BasicOfferResponse>(synopsisOfferResponse, null);
            }

            return new GetBasicOfferResponseDTO<BasicOfferResponse>(null, new ProblemDetails { Title = "Offer does not exist" });
        }

        public async Task<GetBasicListOfferResponseDTO<BasicOfferResponse>> GetAllOffer(GetOfferListRequest request)
        {
            var titles = new List<TitleOfferResponse>();
            var synopsis = new List<DescriptionOfferResponse>();

            var titleOffers = (request.filterByOfferType == null || request.filterByOfferType.Contains(OfferType.Title)) ? _dbContext.MediaTitles.Where(x => x.CreatorUserId != null).ToList() : null;
            var synopsisOffers = (request.filterByOfferType == null ||   request.filterByOfferType.Contains(OfferType.Description)) ? _dbContext.MediaSynopsis.Where(x => x.CreatorUserId != null).ToList() : null;

            titles = _mapper.Map< List<TitleOfferResponse>>(titleOffers);
            synopsis = _mapper.Map< List<DescriptionOfferResponse>>(synopsisOffers);

            var resultList = new List<BasicOfferResponse>();
            if(titles != null) resultList.AddRange(titles);
            if(synopsis!= null) resultList.AddRange(synopsis);

            resultList = (request.sortBy != null && request.sortBy == OfferSort.novelty) ? resultList.OrderBy(x => x.UpdatedAt).ToList() : resultList;
            // relevant sort temp empty

            int count = request.limit;
            if(count > resultList.Count()) count = resultList.Count();

            // Маємо обрізати індекс до максимально можливої довжини
            int index = request.offset;
            if (count + index > resultList.Count()) index = resultList.Count() - count;


            resultList = resultList.GetRange(index, count);
            var result = new BasicListOfferResult<BasicOfferResponse>
            {
                totalApplication = resultList.Count,
                applicationAccepted = resultList.Where(x => x.IsAcceptProposal == true).Count(),
                applicationRejected = resultList.Where(x => x.IsAcceptProposal == false).Count(),
                applicationsArePending = resultList.Where(x => x.IsAcceptProposal == null).Count(),
                results = resultList
            };
            return new GetBasicListOfferResponseDTO<BasicOfferResponse>(result, null);
        }

        private async Task<RootVariantSubItemEntity> MakeDecision(RootVariantSubItemEntity offer, UpdateOfferDecisionRequest decision)
        {
            offer.IsAcceptProposal = decision.isAccept;
            offer.Notes = decision.notes;
            offer.AcceptOfferUserId = _userId;
            offer.UpdatedAt = DateTimeOffset.Now;

            return offer;
        }

        private ProblemDetails? ModeratorFunc(UpdateBasicOfferRequest offerRequest, RootVariantSubItemEntity offerTextVariant)
        {
            bool isModerator = _claimsPrincipal.IsInRole(Role.Administrator.ToString()) || _claimsPrincipal.IsInRole(Role.Moderator.ToString());

            if (offerRequest.IsMain != null && !isModerator) return new ProblemDetails { Title = "You have no right to change IsMain" };
            if (offerRequest.IsHidden != null && !isModerator) return new ProblemDetails { Title = "You have no right to change IsHidden" };
            if (offerRequest.IsOriginal != null && !isModerator) return new ProblemDetails { Title = "You have no right to change IsOriginal" };
            if (offerRequest.Decision != null && !isModerator) return new ProblemDetails { Title = "You have no right to change Decision" };
            
            if (offerRequest.IsMain != null) offerTextVariant.IsMain = offerRequest.IsMain;
            if (offerRequest.IsHidden != null) offerTextVariant.IsHidden = offerRequest.IsHidden;
            if (offerRequest.IsOriginal != null) offerTextVariant.IsOriginal = offerRequest.IsOriginal;

            // Decision Change
            if (offerRequest.Decision != null) MakeDecision(offerTextVariant, offerRequest.Decision);
            return null;
        }

        private bool isUserCanChange(RootVariantSubItemEntity offer)
        {
            // Proposition accept or no accept??
            bool isModerator = _claimsPrincipal.IsInRole(Role.Administrator.ToString()) || _claimsPrincipal.IsInRole(Role.Moderator.ToString());

            if (!isModerator &&
                offer.IsAcceptProposal == null ||
                offer.IsHidden != null ||
                offer.IsHidden != false ||
                offer.CreatorUserId == _userId.ToString()
                ) return true;
            if (isModerator) return true;
            return false;
        }

        // Get Title, Description, Poster obj
        // Get All Proposition List (with diferent types)

        /*        public async Task<ProvidingTranslationOffertResultDTO> CreateOfferAnimeTitle(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
                {
                    var animeItem = _dbContext.Animes.Include(x => x.Titles).FirstOrDefault(item => item.Id == animeId);

                    AnimeTitleEntity title = new AnimeTitleEntity();
                    if (animeItem != null)
                    {
                        title = NewAnimeTitleOfferModel(animeId, providingTranslationOfferInput);
                    }
                    else {
                        return new ProvidingTranslationOffertResultDTO(null, new ProblemDetails { Title = "No media found" });
                    }

                    *//*if (IsUserHasAutomaticAcceptPermission() && IsFirstTitleLanguageProposition(animeId, providingTranslationOfferInput.Language))
                    {
                        title.IsMain = true;
                    }*//*

                    animeItem.Titles.Add(title);

                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        var offerResult = title.Adapt<OfferBasicResultDTO>();
                        return new ProvidingTranslationOffertResultDTO(offerResult, null);
                    }

                    return new ProvidingTranslationOffertResultDTO(null, new ProblemDetails { Title = "Save failure" });
                }*/

        /*  public async Task<ProvidingTranslationOffertResultListDTO> GetOfferAnimeTitles()
          {
              var offerItem = await _dbContext.AnimeTitles.Where(x => x.From == ItemFrom.User).ToListAsync();
              var result = offerItem.Adapt<ProvidingTranslationOffertResultListDTO>();
              return result;
          }*/

        /*    public async Task<ProvidingTranslationOffertResultDTO> GetOfferAnimeTitleById(Guid titleId)
            {
                var offerItem = await _dbContext.AnimeTitles.Where(x => x.Id == titleId).FirstOrDefaultAsync();
                var result = offerItem.Adapt<ProvidingTranslationOffertResultDTO>();
                return result;
            }*/

        /*      public async Task<ProvidingTranslationOffertResultListDTO> GetOfferAnimeSynopsis()
              {
                  var offerItem = await _dbContext.AnimeSynopsises.Where(x => x.From == ItemFrom.User).ToListAsync();
                  var result = offerItem.Adapt<ProvidingTranslationOffertResultListDTO>();
                  return result;
              }*/
        /* public async Task<ProvidingTranslationOffertResultDTO> GetOfferAnimeSynopsisById(Guid titleId)
         {
             var offerItem = await _dbContext.Animes.Where(x => x.Id == titleId).FirstOrDefaultAsync();
             var result = offerItem.Adapt<ProvidingTranslationOffertResultDTO>();
             return result;
         }*/

        /*public async Task<ProvidingTranslationOffertResultDTO> CreateOfferAnimeSynopsis(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
        {
            var animeItem = _dbContext.Animes.Include(x => x.Titles).FirstOrDefault(item => item.Id == animeId);

            AnimeSynopsisEntity synopsis = new AnimeSynopsisEntity();
            if (animeItem != null)
            {
                synopsis = NewAnimeSynopsisOfferModel(animeId, providingTranslationOfferInput);
            }
            else
            {
                return new ProvidingTranslationOffertResultDTO(null, new ProblemDetails { Title = "No media found" });
            }

            animeItem.Synopsises.Add(synopsis);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                var offerResult = synopsis.Adapt<OfferBasicResultDTO>();
                return new ProvidingTranslationOffertResultDTO(offerResult, null);
            }

            return new ProvidingTranslationOffertResultDTO(null, new ProblemDetails { Title = "Save failure" });
        }*/

        /*        private AnimeTitleEntity NewAnimeTitleOfferModel(Guid animeId, ProvidingTranslationOffer providingTranslationOfferInput)
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
                }*/
        /*private MangaTitleEntity NewMangaTitleOfferModel(Guid mangaId, OfferBasicRequest providingTranslationOfferInput)
        {
            MangaTitleEntity title = new MangaTitleEntity();
            title = (MangaTitleEntity)NewTitleVariantModel(title, providingTranslationOfferInput);
            title.MangaId = mangaId;
            return title;
        }*/
        /* private MangaSynopsisEntity NewMangaSynopsisOfferModel(Guid mangaId, OfferBasicRequest providingTranslationOfferInput)
         {
             MangaSynopsisEntity synopsis = new MangaSynopsisEntity();
             synopsis = (MangaSynopsisEntity)NewTitleVariantModel(synopsis, providingTranslationOfferInput);
             synopsis.MangaId = mangaId;
             return synopsis;
         }*/

        /*private TextVariantSubItemEntity NewTitleVariantModel(TextVariantSubItemEntity title, TitleOfferRequest providingTranslationOfferInput)
        {
            title.Body = providingTranslationOfferInput.Name;
            title.CreatorUserId = _userId;
            title.IsMain = false; // ВИзначатиметься після рішення
            title.IsOriginal = false; //Only System
            title.IsAcceptProposal = null; // 
            title.Language = providingTranslationOfferInput.Language;
            title.From = ItemFrom.User;

            return title;
        }*/

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

        /*   private void MapConfigurate()
           {
               TypeAdapterConfig<AnimeTitleEntity, OfferBasicResultDTO>.NewConfig()
               .Map(
                   dest => dest.Language,
                   src => src.Language.ToString());

               TypeAdapterConfig<List<AnimeTitleEntity>, ProvidingTranslationOffertResultListDTO>.NewConfig()
               .Map(
                   dest => dest.Result,
                   src => src);
           }*/
    }
}
