using HotChocolate.Execution;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;
using NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO;
using NekoSpace.API.Contracts.Models.User;
using NekoSpace.API.Contracts.Models.User.Library.Update;
using NekoSpace.API.Contracts.Models.UserService;
using NekoSpace.API.Contracts.Models.UserService.UserUpdates;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Data.Models.User;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using Nest;
using System.Linq;
using System.Security.Claims;

namespace NekoSpace.Core.Services.UserService
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly UserEntity _authUserContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _claimsPrincipal = claimsPrincipal;
            _mapper = mapper;

            string userId = _userManager.GetUserId(_claimsPrincipal);
            _authUserContext = _dbContext.Users
                .Include(x => x.RatingAnimes).ThenInclude(x => x.Anime)
                .Include(x => x.FavoriteAnimes).ThenInclude(x => x.Anime)
                .Include(x => x.AnimeViewingStatuses).ThenInclude(x => x.Anime)
                .Single(item => item.Id == userId);

            MapConfigurate();
        }

        public async Task<UserResultDTO> GetMe()
        {
            var userResponse = _authUserContext.Adapt<UserResponse>();
            var userIdentity = _claimsPrincipal.Identities;
            
            foreach(ClaimsIdentity role in userIdentity)
            {
                userResponse.Roles.Add(role.Name.ToString());
            }

            var userResult = new UserResultDTO(userResponse, null);
            return userResult;
        }

        public async Task<UserListResponseDTO> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var usersResult = users.Adapt<List<UserResponse>>();
            var response = new UserListResponse { numberOfUsers = usersResult.Count(), users = usersResult };

            return new UserListResponseDTO(response, null);
        }

        public async Task<UserResultDTO> GetUser(Guid userId)
        {
            var user = _userManager.FindByIdAsync(userId.ToString()).Result;
            if (user == null) return new UserResultDTO(null, new ProblemDetails { Title = "No user found for this id" , Status = 404 });

            var userResponse = user.Adapt<UserResponse>();

            var userIdentity = _userManager.GetRolesAsync(user).Result;
            foreach (string role in userIdentity)
            {
                userResponse.Roles.Add(role);
            }

            return new UserResultDTO(userResponse, null);
        }

        public async Task<GetBasicListOfferResponseDTO<BasicOfferResponse>> GetUserOffers(Guid userId)
        {
            var userTitleOffers = _dbContext.MediaTitles.Where(x => x.CreatorUserId == userId.ToString()).ToList();
            var userSynopsisOffers = _dbContext.MediaSynopsis.Where(x => x.CreatorUserId == userId.ToString()).ToList();

            var titles = _mapper.Map<List<TitleOfferResponse>>(userTitleOffers);
            var synopsis = _mapper.Map<List<DescriptionOfferResponse>>(userSynopsisOffers);

            var userOffersResult = new List<BasicOfferResponse>();
            if (titles != null) userOffersResult.AddRange(titles);
            if (synopsis != null) userOffersResult.AddRange(synopsis);

            var result = new BasicListOfferResult<BasicOfferResponse> {
                totalApplication = userOffersResult.Count,
                applicationAccepted = userOffersResult.Where(x => x.IsAcceptProposal == true).Count(),
                applicationRejected = userOffersResult.Where(x => x.IsAcceptProposal == false).Count(),
                applicationsArePending = userOffersResult.Where(x => x.IsAcceptProposal == null).Count(),
                results = userOffersResult
            };

            return new GetBasicListOfferResponseDTO<BasicOfferResponse>(result, null);
        }

        public void AddRole(Guid userId, Role newRole)
        {
            var user = _userManager.FindByIdAsync(userId.ToString()).Result;
            var existingRoles = _userManager.GetRolesAsync(user).Result.ToList();

            if (existingRoles.Contains(newRole.ToString())) return;

            var result = _userManager.AddToRoleAsync(user, newRole.ToString()).Result;
            if (!result.Succeeded)
            {
                throw new Exception($"Error managing roles of the user. "); // Server error
            }

            return;
        }
        public void RemoveRole(Guid userId, Role newRole)
        {
            var user = _userManager.FindByIdAsync(userId.ToString()).Result;
            var existingRoles = _userManager.GetRolesAsync(user).Result.ToList();

            if (!existingRoles.Contains(newRole.ToString())) return;

            var result = _userManager.RemoveFromRoleAsync(user, newRole.ToString()).Result;
            if (!result.Succeeded)
            {
                throw new Exception($"Error managing roles of the user. "); // Server error
            }

            return;
        }

        public async Task<UserUpdateResult> UpdateMe(UserUpdateCommand userUpdateCommand)
        {
            _authUserContext.About = userUpdateCommand.About;
            if (_dbContext.SaveChanges() > 0) return new UserUpdateResult(true, null);
            return new UserUpdateResult(false, new ProblemDetails { Title = "Error saving data" });
        }

        public async Task<UserLibraryResult> GetLibrary()
        {
            UserLibraryResponse userLibraryResponse = new UserLibraryResponse();

            foreach(UserRatingAnimeEntity ratingItem in _authUserContext.RatingAnimes)
            {
                UserAnimeRatingResponse userAnimeRatingResponse = ratingItem.Adapt<UserAnimeRatingResponse>();
                userLibraryResponse.UserAnimeRatingResponses.Add(userAnimeRatingResponse);
            }

            foreach(UserAnimeViewingStatusEntity viewStatusItem in _authUserContext.AnimeViewingStatuses)
            {
                UserAnimeViewingStatusResponse userAnimeViewingStatusResponse = viewStatusItem.Adapt<UserAnimeViewingStatusResponse>();
                userLibraryResponse.UserAnimeViewingStatusResponses.Add(userAnimeViewingStatusResponse);
            }

            foreach (UserFavoriteAnimeEntity userFavoriteAnimeEntity in _authUserContext.FavoriteAnimes)
            {
                UserFavoriteAnimeResponse userFavoriteAnimeResponse = userFavoriteAnimeEntity.Adapt<UserFavoriteAnimeResponse>();
                userLibraryResponse.UserFavoriteAnimeResponses.Add(userFavoriteAnimeResponse);
            }

            return new UserLibraryResult(userLibraryResponse, null);
        }

        public async Task<UpdateUserLibraryResult> UpdateLibraryAsync(UpdateUserLibrary updateUserLibrary)
        {
            // GetAnimeObj
            var animeContext = await _dbContext.Animes.FirstOrDefaultAsync(item => item.Id == updateUserLibrary.AnimeId);

            if (animeContext == null) return new UpdateUserLibraryResult(false, new ProblemDetails { Title = "Could not find this media. Did you enter the ID correctly?" });

            // Update
            if (updateUserLibrary.UserViewStatus != null)
            {
                ChangeAnimeViewStatus(animeContext, updateUserLibrary.UserViewStatus);
            }

            if (updateUserLibrary.Score != null)
            {
                ChangeAnimeScore(animeContext, updateUserLibrary.Score);
            }

            if (updateUserLibrary.IsFavorite != null)
            {
                ChangeAnimeFavoriteStatus(animeContext, updateUserLibrary.IsFavorite);
            }


            if (_dbContext.SaveChanges() > 0) return new UpdateUserLibraryResult(true, null);
            return new UpdateUserLibraryResult(false, new ProblemDetails { Title = "Error saving data" });
        }

        private async Task ChangeAnimeFavoriteStatus(AnimeEntity animeContext, bool? isFavorite)
        {
            var mainFavoriteEntity = await _dbContext.UserFavoriteAnime.FirstOrDefaultAsync(item => item.UserId == _authUserContext.Id && item.AnimeId == animeContext.Id);
            if (mainFavoriteEntity == null)
            {
                if (isFavorite == true)
                {
                    var newRelation = new UserFavoriteAnimeEntity
                    {
                        Anime = animeContext,
                        User = _authUserContext
                    };
                    await _dbContext.UserFavoriteAnime.AddAsync(newRelation);
                }
            }
            else
            {
                if (isFavorite == false)
                {
                    _dbContext.UserFavoriteAnime.Remove(mainFavoriteEntity);
                }
            }
        }

        private async Task ChangeAnimeScore(AnimeEntity animeContext, float? viewStatus)
        {
            var mainRatingEntity = _dbContext.UserRatingAnime.FirstOrDefault(item => item.UserId == _authUserContext.Id && item.AnimeId == animeContext.Id);
            if (mainRatingEntity != null)
            {
                mainRatingEntity.RatingValue = viewStatus ?? 0;
                mainRatingEntity.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                // Mapping
                UserRatingAnimeEntity newViewingStatusEntity = new UserRatingAnimeEntity
                {
                    User = _authUserContext,
                    Anime = animeContext,
                    RatingValue = viewStatus ?? 0
                };
                _dbContext.UserRatingAnime.Add(newViewingStatusEntity);
            }
        }

        private async Task ChangeAnimeViewStatus(AnimeEntity animeContext, UserViewStatus? viewStatus)
        {
            var mainViewingStatusEntity = _dbContext.UserAnimeViewingStatus.FirstOrDefault(item => item.UserId == _authUserContext.Id && item.AnimeId == animeContext.Id);
            if (mainViewingStatusEntity != null)
            {
                mainViewingStatusEntity.Status = viewStatus ?? UserViewStatus.None;
                mainViewingStatusEntity.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                // Mapping
                UserAnimeViewingStatusEntity newViewingStatusEntity = new UserAnimeViewingStatusEntity
                {
                    User = _authUserContext,
                    Anime = animeContext,
                    Status = viewStatus ?? UserViewStatus.None
                };
                _dbContext.UserAnimeViewingStatus.Add(newViewingStatusEntity);
            }
        }

        private void MapConfigurate()
        {
            TypeAdapterConfig<UserEntity, UserResponse>.NewConfig()
            .Map(
            dest =>  dest.UserId,
            src => src.Id);

            TypeAdapterConfig<UserRatingAnimeEntity, UserAnimeRatingResponse>.NewConfig()
            .Map(
            dest => dest.Score,
            src => src.RatingValue);
        }
    }
}
