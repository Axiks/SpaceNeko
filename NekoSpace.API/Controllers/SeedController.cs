using Arch.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NekoSpace.API.Helpers;
using NekoSpace.Core.Services.DatabaseService;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.Seed;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using System;

namespace NekoSpace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private IServiceScopeFactory scopeFactory;
        private ApplicationDbContext _dbContext;
        private IDbContextFactory<ApplicationDbContext> _contextFactory;
        // private readonly SeedingService oldSeedingService;
        // private readonly ISeedingService _seedingService;

        public SeedController(IDbContextFactory<ApplicationDbContext> contextFactory, IServiceScopeFactory scopeFactory)
        {
            //_dbContext = dbContext;
            //this.scopeFactory = scopeFactory;
            _contextFactory = contextFactory;


            //var factory = new WebApplicationFactory<Startup>();
            /*using var scope = factory.Server.Services
                .GetService<IServiceScopeFactory>().CreateScope();*/

            /*using var scope = scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                AnimeEntity animeEntity = new AnimeEntity();

                animeEntity.Type = Data.Contracts.Enums.AnimeType.Special;
                animeEntity.AgeRating = Data.Contracts.Enums.AgeRating.pg13;
                animeEntity.AiringStatus = Data.Contracts.Enums.AiringStatus.CurrentlyAiring;
                animeEntity.Source = Common.Enums.Source.Music;

                dbContext.Animes.Add(animeEntity);
                int c = dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/


            /*using var scope = app.Services.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();*/


            //oldSeedingService = new SeedingService(_dbContext);

            //_seedAnsibleService = new SeedAnsibleService(dbContext);

            /* AnimeEntity animeEntity = new AnimeEntity();

             animeEntity.Type = Data.Contracts.Enums.AnimeType.Special;
             animeEntity.AgeRating = Data.Contracts.Enums.AgeRating.pg13;
             animeEntity.AiringStatus = Data.Contracts.Enums.AiringStatus.CurrentlyAiring;
             animeEntity.Source = Common.Enums.Source.Music;

             try
             {
                 context.Animes.Add(animeEntity);
                 int c = context.SaveChanges();
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/
        }

        /*[HttpGet]
        public async Task<IActionResult> OldRunSeed()
        {
            //oldSeedingService.RunAsync();
            return Ok();
        }*/

        [HttpGet]
        public void RunSeed()
        {
            /*using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                ISeedingService _seedingService = new SeedingService(dbContext);
                _seedingService.RunAsync();
            }*/

            /*using var scope = app.Services.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();*/

            using (ApplicationDbContext dbContext = _contextFactory.CreateDbContext())
            {
                ISeedingService _seedingService = new SeedingService(dbContext);
                _seedingService.RunAsync();
                /*try
                {
                    AnimeEntity animeEntity = new AnimeEntity();

                    animeEntity.Type = Data.Contracts.Enums.AnimeType.Special;
                    animeEntity.AgeRating = Data.Contracts.Enums.AgeRating.pg13;
                    animeEntity.AiringStatus = Data.Contracts.Enums.AiringStatus.CurrentlyAiring;
                    animeEntity.Source = Common.Enums.Source.Music;

                    dbContext.Animes.Add(animeEntity);
                    int c = dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }*/
            }

        }
    }
}
