using AnimeDB;
using NekoSpace.Data.Interfaces;
using NekoSpace.Data.Repository;
using NekoSpaceList.Models.Anime;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NekoSpaceList.Models.Manga;
using NekoSpaceList.Models.CharacterModels;
using NekoSpace.Data.Models.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using HotChocolate.AspNetCore.Authorization;

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
        [UseFiltering]
        [UseSorting]

        public IQueryable<Anime> GetAnime([ScopedService] ApplicationDbContext dbContext)
        {
            /*var ani = dbContext.Animes;
            return ani;*/
            return dbContext.Animes;
        }

        public IQueryable<Manga> GetManga([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Mangas;
        }

        public IQueryable<Character> GetCharacter([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Characters;
        }

        [Authorize]
        public async Task<NekoUser> GetMe(ClaimsPrincipal claimsPrincipal, [Service] UserManager<NekoUser> userManager)
        {
            var user = await userManager.GetUserAsync(claimsPrincipal);
            //var email = user.Email;
            return user;

            // Omitted code for brevity
            //var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = claimsPrincipal.Identity;

        }

    }
}
