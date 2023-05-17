using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Core.Services.DatabaseService;
using NekoSpace.Data;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SeedingService seedingService;

        public SeedController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            seedingService = new SeedingService(_dbContext);
        }

        [HttpGet("[action]")]
        public IActionResult RunSeed()
        {
            seedingService.RunAsync();
            return Ok();
        }
    }
}
