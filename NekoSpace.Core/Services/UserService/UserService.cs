using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Contracts.Models.UserService.User;
using NekoSpace.API.Contracts.Models.UserService.UserUpdates;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.Data.Models.User;
using NekoSpaceList.Models.Anime;
using NuGet.Protocol;
using System.Security.Claims;
using System.Xml.Linq;

namespace NekoSpace.Core.Services.UserService
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly UserEntity _authUserContext;

        public UserService(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _claimsPrincipal = claimsPrincipal;

            string userId = _userManager.GetUserId(_claimsPrincipal);
            _authUserContext = _dbContext.Users
                .Include(x => x.RatingAnimes).ThenInclude(x => x.Anime)
                .Include(x => x.FavoriteAnimes).ThenInclude(x => x.Anime)
                .Include(x => x.AnimeViewingStatuses).ThenInclude(x => x.Anime)
                .Single(item => item.Id == userId);

            MapConfigurate();
        }

        public async Task<UserGetResult> GetMe()
        {
            var userResponse = _authUserContext.Adapt<UserGetResponse>();
            var userIdentity = _claimsPrincipal.Identities;
            
            foreach(ClaimsIdentity role in userIdentity)
            {
                userResponse.Roles.Add(role.Name.ToString());
            }

            var userResult = new UserGetResult(userResponse, null);
            return userResult;
        }

        public async Task<UserUpdateResult> UpdateMe(UserUpdateCommand userUpdateCommand)
        {
            _authUserContext.About = userUpdateCommand.About;
            if (_dbContext.SaveChanges() > 0) return new UserUpdateResult(true, null);
            return new UserUpdateResult(false, "Error saving data");
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

        public async Task<UpdateUserResult> UpdateLibraryAsync(UpdateLibraryCommand updateLibraryCommand)
        {
            // GetAnimeObj
            var animeContext = await _dbContext.Animes.FirstOrDefaultAsync(item => item.Id == updateLibraryCommand.AnimeId);

            if (animeContext == null) return new UpdateUserResult(false, "Could not find this media. Did you enter the ID correctly?");

            // Update
            if (updateLibraryCommand.UserViewStatus != null)
            {
                ChangeAnimeViewStatus(animeContext, updateLibraryCommand.UserViewStatus);
            }

            if (updateLibraryCommand.Score != null)
            {
                ChangeAnimeScore(animeContext, updateLibraryCommand.Score);
            }

            if (updateLibraryCommand.IsFavorite != null)
            {
                ChangeAnimeFavoriteStatus(animeContext, updateLibraryCommand.IsFavorite);
            }


            if (_dbContext.SaveChanges() > 0) return new UpdateUserResult(true, null);
            return new UpdateUserResult(false, "Error saving data");
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
            TypeAdapterConfig<UserEntity, UserGetResponse>.NewConfig()
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
