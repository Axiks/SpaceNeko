using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using NekoSpace.API.Contracts.Abstract;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.API.Contracts.Models.Media;
using NekoSpace.Core.Services.AnimeService;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.Manga;
using Swashbuckle.AspNetCore.Annotations;
using System.Drawing;
using static Nest.JoinField;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private AnimeService _service;
        private IMapper _mapper;

        public SearchController(AnimeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ResponseMedia))]
        public async Task<IActionResult> Get([FromQuery] GetMediaQueryParameters parameters)
        {
            //Fix 
            var aniParams = _mapper.Map<GetAnimeQueryParameters>(parameters);
            var aniDTO = _service.GetAnimeList(aniParams);

            return Ok(aniDTO.Result);
        }

    }
}
