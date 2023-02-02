using AnimeDB;
using NekoSpaceList.Models.Anime;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NekoSpaceList.Models.Manga;
using NekoSpaceList.Models.CharacterModels;
using NekoSpace.Data.Models.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using HotChocolate.AspNetCore.Authorization;
using NekoSpace.API.General;
using NekoSpace.API.GraphQL.Search;

namespace NekoSpace.API.GraphQL
{
    public class Query
    {

        public Query()
        {
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 100)]
        [UseProjection]
        [HotChocolate.Types.UseFiltering]
        [UseSorting]

        public IQueryable<Anime> GetAnime([ScopedService] ApplicationDbContext dbContext)
        {
            /*var ani = dbContext.Animes;
            return ani;*/
            return dbContext.Animes;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 100)]
        [UseProjection]
        [HotChocolate.Types.UseFiltering]
        [UseSorting]

        public IQueryable<AnimeTitle> GetAnimeTitle([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.AnimeTitles
                .Include(u => u.Anime);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 100)]
        [UseProjection]
        [HotChocolate.Types.UseFiltering]
        [UseSorting]

        public IQueryable<AnimeSynopsis> GetAnimeSynopsis([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.AnimeSynopsises
                .Include(u => u.Anime);
        }

        /* public IQueryable<Manga> GetManga([ScopedService] ApplicationDbContext dbContext)
         {
             return dbContext.Mangas;
         }*/

        /*public IQueryable<Character> GetCharacter([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Characters;
        }*/

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<AnimeTitle> SearchAnimeByName(SearchInput input, [ScopedService] ApplicationDbContext dbContext)
        {
            /*List<SearchAnimeItem> searchAnimeItems = new List<SearchAnimeItem>();
            var searchTitles = context.AnimeTitles.Where(item => item.Body.Contains(input.query)).Take(input.first);
            if (searchTitles.Count() > 0)
            {
                foreach (var searchTitle in searchTitles)
                {
                    var itemToAdd = new SearchAnimeItem(animeId: searchTitle.MediaId, currentAnimeTitle: searchTitle.Body, posterSrc: null);
                    searchAnimeItems.Add(itemToAdd);
                }
            }

            return new SearchPayload(searchAnimeItems, null);*/

            /*List<SearchAnimeItem> searchAnimeItems = new List<SearchAnimeItem>();
            var searchTitles = context.AnimeTitles.Where(item => item.Body.Contains(input.query)).Take(input.first);
            if (searchTitles.Count() > 0)
            {
                foreach (var searchTitle in searchTitles)
                {
                    var searchAnime = context.Animes.Single(item => item.Id == searchTitle.MediaId);
                    var itemToAdd = new SearchAnimeItem(anime: searchAnime, currentAnimeTitle: searchTitle);
                    searchAnimeItems.Add(itemToAdd);
                }
            }

            var searchPayload = new SearchPayload(searchAnimeItems);
            return searchPayload;*/

            //List<SearchAnimeItem> searchAnimeItems = new List<SearchAnimeItem>();
            //var searchTitles = dbContext.AnimeTitles.Where(item => item.Body.Contains(input.query)).Take(input.first);

            //var searchAnime = dbContext.Animes.Include(a => a.Titles).ThenInclude(a => a.Body.Contains(input.query)).Take(input.first);

            var searchAnime2 = dbContext.AnimeTitles.Include(i => i.Anime).Where(t => t.Body.Contains(input.query));
            //var searchAnime2 = dbContext.AnimeTitles.Include(i => i.Anime)

            /*var searchAnime = from anime in dbContext.Animes.Include(a => a.Titles)
                              where 
                              ;

            var searchAnime2 = from title in dbContext.AnimeTitles.Include(t=> t.Anime)
                               where title.Body
                ;
            */


            return searchAnime2;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [Authorize]
        [UseProjection]
        public async Task<NekoUser> GetMe(ClaimsPrincipal claimsPrincipal, [ScopedService] ApplicationDbContext dbContext, [Service] UserManager<NekoUser> userManager)
        {
            var user = await userManager.GetUserAsync(claimsPrincipal);

            var userDbContext = await dbContext.Users
                .Include(u => u.FavoriteAnimes).ThenInclude(u => u.Anime).ThenInclude(u => u.Titles)
                .Include(u => u.FavoriteAnimes).ThenInclude(u => u.Anime.Posters).ThenInclude(u => u.Poster)
                .Include(u => u.AnimeViewingStatuses)
                /*.Include(u => u.AnimeViewingStatuses).ThenInclude(u => u.Anime).ThenInclude(u => u.Titles)
                .Include(u => u.RatingAnimes).ThenInclude(u => u.Anime).ThenInclude(u => u.Titles)*/
                .Include(u => u.RatingAnimes)
                .FirstAsync(t => t.Id == user.Id);
            //var email = user.Email;
            return userDbContext;
        }

        [Authorize]
        public async Task<List<bool>> CheckClaim(ClaimsPrincipal claimsPrincipal, [Service] UserManager<NekoUser> userManager)
        {
            /*var user = await userManager.GetUserAsync(claimsPrincipal);
            //var email = user.Email;
            return user;*/

            //Filter specific claim    
            //claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;

            // Omitted code for brevity
            /*var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            *//*var user = claimsPrincipal.Identity.Name;
            return user;*//*

            //First get user claims    
            var claims = claimsPrincipal.Identities.First().Claims.ToList();
            //Filter specific claim    
            var a = claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;
            return claims;*/

            var avaibleRoles = new List<bool>
            {
                claimsPrincipal.IsInRole(Roles.AdministratorRole),
                claimsPrincipal.IsInRole(Roles.ModeratorRole),
                claimsPrincipal.IsInRole(Roles.CreatorRole),
                claimsPrincipal.IsInRole(Roles.UserRole),
            };


            //return claimsPrincipal.IsInRole(Roles.AdministratorRole);
            return avaibleRoles;

        }


    }
}
