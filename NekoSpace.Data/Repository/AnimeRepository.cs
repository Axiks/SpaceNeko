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

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);

            

            //Func<Anime> anilambda = c => c.

            //var lam = _dbContext.Set<Anime>().Include();
            //var aa = x => x.Id;
        }
        /*public override IQueryable<Anime> GetAll(int limit, int offset) {
            
        }*/

    }
}
