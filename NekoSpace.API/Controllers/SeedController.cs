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
        private IDbContextFactory<ApplicationDbContext> _contextFactory;

        public SeedController(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

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
            }

        }
    }
}
