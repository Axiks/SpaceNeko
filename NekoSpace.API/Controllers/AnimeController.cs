
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

        [HttpGet]
        public async Task<IActionResult> GetAnime(string? q, int limit = 40, int offset = 0)
        {
            var service = new AnimeService(_dbContext);
            var anime = await service.GetAnimeList(q, limit, offset);
            return Ok(anime);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAnimeById(Guid id)
        {
            var service = new AnimeService(_dbContext);
            var anime = await service.GetAnimeById(id);
            if(anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchAnimeByName(string q)
        {
            var service = new AnimeService(_dbContext);
            var result = await service.SearchAnimeByName(q);
            return Ok(result);
        }

       /* [HttpPost("{Id}/Update")]
        public async Task<IActionResult> UpdateAnime(Guid id)
        {

            *//*var service = new AnimeService(_dbContext);
            var result = service.SearchAnimeByName(q);
            return Ok(result);*//*
            return Ok();
        }*/

        // Create translation proposition title
        // Create translation proposition synopsis
        // Decision proposition
        // Set main
        // Update anime data

    }
}
