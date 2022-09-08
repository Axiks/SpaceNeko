using AnimeDB;
using NekoSpace.Data.Interfaces;
using NekoSpace.Data.Repository;
using NekoSpaceList.Models.Anime;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NekoSpaceList.Models.Manga;
using NekoSpaceList.Models.CharacterModels;

namespace NekoSpace.API.GraphQL
{
    public class Query
    {

        public Query()
        {
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Anime> GetAnime([ScopedService] ApplicationDbContext dbContext)
        {
            var ani = dbContext.Animes;
            return ani;
        }

        public IQueryable<Manga> GetManga([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Mangas;
        }

        public IQueryable<Character> GetCharacter([ScopedService] ApplicationDbContext dbContext)
        {
            return dbContext.Characters;
        }

    }
}
