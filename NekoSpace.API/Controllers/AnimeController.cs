
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Core.Services.AnimeService;
using NekoSpace.Data;

namespace NekoSpace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AnimeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet()]
        public IActionResult GetAnime(int limit = 100, int offset = 0)
        {
            var service = new AnimeService(_dbContext);
            var anime = service.GetAnimeList(limit, offset);
            return Ok(anime);
        }

        [HttpGet("{Id}")]
        public IActionResult GetAnimeById(Guid id)
        {
            var service = new AnimeService(_dbContext);
            var anime = service.GetAnimeById(id);
            return Ok(anime);
        }

        [HttpGet("Search")]
        public IActionResult SearchAnimeByName(string q)
        {
            var service = new AnimeService(_dbContext);
            var result = service.SearchAnimeByName(q);
            return Ok(result);
        }

        // Create translation proposition title
        // Create translation proposition synopsis
        // Decision proposition
        // Set main
        // Update anime data

    }
}
