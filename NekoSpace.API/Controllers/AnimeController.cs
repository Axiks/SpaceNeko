using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.API.Contracts.Models.Media;
using NekoSpace.Core.Services.AnimeService;
using Swashbuckle.AspNetCore.Annotations;

namespace NekoSpace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private AnimeService _animeService;

        public AnimeController(AnimeService animeService)
        {
            _animeService = animeService;
        }

        /*[HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ResponseMedia))]
        public async Task<IActionResult> GetAnime([FromQuery] GetAnimeQueryParameters parameters)
        {
            var aniDTO = _animeService.GetAnimeList(parameters);

            return Ok(aniDTO.Result);
        }*/

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAnimeResultDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAnimeById(Guid id)
        {
            var anime = await _animeService.GetAnimeById(id);
            if(anime == null) return NotFound();

            return Ok(anime);
        }

    }
}
