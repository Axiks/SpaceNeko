using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Core.Services.AnimeService;
using NekoSpace.Data;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<GetAnimeResultDTO>))]
        public async Task<IActionResult> GetAnime([FromQuery] GetAnimeQueryParameters parameters)
        {
            var service = new AnimeService(_dbContext);
            var anime = await service.GetAnimeList(parameters);
            return Ok(anime);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAnimeResultDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
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

        /*[HttpGet("Search")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SearchAnimeResultDTO))]
        public async Task<IActionResult> SearchAnimeByName(string q)
        {
            var service = new AnimeService(_dbContext);
            var result = await service.SearchAnimeByName(q);
            return Ok(result);
        }*/

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
