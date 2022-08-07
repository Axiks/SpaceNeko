using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;

namespace NekoSpace.Data.Repository
{
    public class AnimeRepository : EFBasicAbstractRepository<Anime>, IAnimeRepository
    {
        public AnimeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
