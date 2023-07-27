using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Core.Services.AnimeService;
using NekoSpace.Data;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository;
using NekoSpace.Repository.Repositories;
using NekoSpaceList.Models.Anime;
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

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<GetAnimeResultDTO>))]
        public async Task<IActionResult> GetAnime([FromQuery] GetAnimeQueryParameters parameters)
        {
            var result = _animeService.GetAnimeList(parameters);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetAnimeResultDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAnimeById(Guid id)
        {
            var anime = await _animeService.GetAnimeById(id);
            if(anime == null)
            {
                return NotFound();
            }
            return Ok(anime);
        }

        [HttpGet("SearchOld")]
        public async Task<IActionResult> SearchAnimeByName(string q)
        {
            var result = await _animeService.SearchAnimeByName(q);
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
