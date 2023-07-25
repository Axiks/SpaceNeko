using Arch.EntityFrameworkCore;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NekoSpace.API.Helpers;
using NekoSpace.Core.Services.DatabaseService;
using NekoSpace.Data;
using NekoSpace.Data.Contracts.Entities.Anime;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository;
using NekoSpace.Repository.Repositories;
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
        private IMapper _mapper;
        private IConfiguration _configurate;
        private AnimeRepository _animeRepository;
        public SeedController(IDbContextFactory<ApplicationDbContext> contextFactory, AnimeRepository animeRepository, IConfiguration configurate, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _configurate = configurate;
            _animeRepository = animeRepository;
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
                ISeedingService _seedingService = new SeedingService(_animeRepository, _mapper);
                _seedingService.RunAsync();
            }

        }
    }
}
