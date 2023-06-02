using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.ElasticSearch;
using NekoSpaceList.Models.Anime;
using Nest;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly ESAnimeService _esAnimeController;

        public ElasticSearchController(IElasticClient elasticSearchExtensions)
        {
            _elasticClient = elasticSearchExtensions;
            _esAnimeController = new ESAnimeService(elasticSearchExtensions);
        }

        [HttpPost("test")]
        public async Task<IActionResult> Create()
        {
            try
            {
                var article = new AnimeEntity()
                {
                    Id = Guid.NewGuid(),
                    UpdatedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.Now
                };
                //await _elasticClient.IndexDocumentAsync(article);
                _esAnimeController.SaveSingleAsync(article);
            }
            catch (Exception ex) { }
            return Ok();
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromQuery] GetAnimeQueryParameters parameters)
        {
            try
            {
                var res = _esAnimeController.GetAnime(parameters);
                return Ok(res);
            }
            catch (Exception ex) { }
            return Ok();
        }
    }
}
