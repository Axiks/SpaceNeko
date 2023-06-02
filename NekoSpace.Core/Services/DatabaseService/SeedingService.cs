using Microsoft.EntityFrameworkCore;
using NekoSpace.API.Helpers;
using NekoSpace.Data;
using NekoSpace.ElasticSearch;
using NekoSpace.Seed.Driver;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using Nest;

namespace NekoSpace.Core.Services.DatabaseService;
public class SeedingService : ISeedingService
{
    private ApplicationDbContext _context;
    // private IRepositoryDriver<Anime, int> _dBSeed;
    private ISelectMediaAll<AnimeEntity> _animeSelectAllDriver;

    private readonly IElasticClient _elasticClient;
    private readonly ESAnimeService _esAnimeController;
    public SeedingService(ApplicationDbContext context, IElasticClient elasticSearchExtensions)
    {
        _context = context;
        _animeSelectAllDriver = new MamiAnimeDriver();

        _elasticClient = elasticSearchExtensions;
        _esAnimeController = new ESAnimeService(elasticSearchExtensions);
    }

    public async Task RunAsync()
    {
        // Завантажуємо дані з зовнішнього джерела
        //var animes = _dBSeed.RunSeed().ToList(); // Remote db data
        var animesRTO = _animeSelectAllDriver.GetAll();

        // Перевіряємо, рядок за рядком, чи дані ідентичні. Якщо ні, оновлюємо (вказуємо за якими полями перевіряти)
        //List<AnimeEntity> animeListNeedToAdd = new List<AnimeEntity>();

        int c = 0;
        foreach (RTO<AnimeEntity> animeRTO in animesRTO)
        {
            var anime = animeRTO.contain;
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
                ElasticSearchAnimeAsync(anime);
            }
        }


        _context.SaveChanges();
        Console.WriteLine("Add new item record: " + c.ToString());
    }

    public async Task ElasticSearchAnimeAsync(AnimeEntity anime)
    {
        _esAnimeController.SaveSingleAsync(anime);
    }
}
