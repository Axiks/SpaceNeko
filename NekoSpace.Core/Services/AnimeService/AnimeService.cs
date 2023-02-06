using NekoSpace.Data;

namespace NekoSpace.Core.Services.AnimeService
{
    public class AnimeService
    {
        private ApplicationDbContext _dbContext;
        public AnimeService([ScopedService] ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        /*public void GetAllAnime()
        {
            return _dbContext.Animes;
        }*/
    }
}
