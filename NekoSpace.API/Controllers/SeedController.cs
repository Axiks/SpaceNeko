using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Core.Services.DatabaseService;
using NekoSpace.Data;
using Nest;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SeedingService seedingService;

        public SeedController(ApplicationDbContext dbContext, IElasticClient elasticSearchExtensions)
        {
            _dbContext = dbContext;
            seedingService = new SeedingService(_dbContext, elasticSearchExtensions);
        }

        [HttpGet("[action]")]
        public IActionResult RunSeed()
        {
            seedingService.RunAsync();
            return Ok();
        }
    }
}
