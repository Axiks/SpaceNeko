using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.Helpers
{
    public class UpdateDB : IUpdateDB
    {
        private ApplicationDbContext _context;
        private IDBSeed<Anime> _dBSeed;
        public UpdateDB([ScopedService] ApplicationDbContext context, IDBSeed<Anime> dBSeed)
        {
            _context = context;
            _dBSeed = dBSeed;
        }

        public async Task RunAsync()
        {
            // Завантажуємо дані з зовнішнього джерела
            var animes = _dBSeed.RunSeed().ToList(); // Remote db data

            // Перевіряємо, рядок за рядком, чи дані ідентичні. Якщо ні, оновлюємо (вказуємо за якими полями перевіряти)
            List<Anime> animeListNeedToAdd = new List<Anime>();

            int c = 0;
            foreach (Anime anime in animes)
            {
                var externalDBMalId = anime.AnotherService.MyAnimeList;
                /*
                if (externalDBMalId is not null)
                {
                    var t = await IsParagemOnGoingAsync((int)externalDBMalId);
                }*/

                /*var query = from p in _context.Animes
                            where p.AnotherService.MyAnimeList == externalDBMalId
                            select new
                            {
                                p.Id
                            };


                var tt = query.FirstOrDefault().Id;*/


                /*if(query.Count() > 0)
                {

                }*/

                //var testSelect = _context.Animes.


                var sss = _context.Animes.
                    Where(o => o.AnotherService.MyAnimeList == externalDBMalId).Count();

                //var ooo = _context.Animes.Any(o => o.AnotherService.MyAnimeList == anime.AnotherService.MyAnimeList);
                //var oooF = _context.Animes.Any(o => o.AnotherService.MyAnimeList != anime.AnotherService.MyAnimeList);

                if (!_context.Animes.Any(o => o.AnotherService.MyAnimeList == anime.AnotherService.MyAnimeList))
                {
                    //animeListNeedToAdd.Add(anime);
                    _context.Animes.Add(anime);
                }
            }


            _context.SaveChanges();
            Console.WriteLine("Add new item record: " + c.ToString());
        }

        public async Task<Guid> IsParagemOnGoingAsync(int externalDBMalId)
        {
            var query = from p in _context.Animes
                        where p.AnotherService.MyAnimeList == externalDBMalId
                        select new
                        {
                            p.Id
                        };


            return query.FirstOrDefaultAsync().Result.Id;
        }
    }
}
