using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Interfaces;
using NekoSpaceList.Models.Manga;

namespace NekoSpace.Data.Repository
{
    public class MangaRepository : EFBasicAbstractRepository<Manga>, IMangaRepository
    {
        public MangaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
