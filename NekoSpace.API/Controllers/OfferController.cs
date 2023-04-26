using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;
using System.Security.Claims;
using NekoSpace.Core.Services.OfferController;
using NekoSpace.Core.Contracts.Models.ProvidingTranslationOfferService;
using Microsoft.AspNetCore.Authorization;
using JikanDotNet;
using NekoSpace.API.Contracts.Abstract.General;
using Swashbuckle.AspNetCore.Annotations;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferController : ControllerBase
    {
        private readonly OfferService _offerService;
        public OfferController(ClaimsPrincipal claimsPrincipal, ApplicationDbContext dbContext)
        {
            _offerService = new OfferService(claimsPrincipal, dbContext);
        }

        [HttpGet("anime/titles")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<OfferBasicResultDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult GetAnimeTitlesOffer()
        {
            var resultAsync = _offerService.GetOfferAnimeTitles();
            resultAsync.Wait();
            var result = resultAsync.Result;
            if (result.Error == null)
            {
                return Ok(result.Result);
                //return CreatedAtAction(result.Result);
            }
            return Problem(result.Error.Message, statusCode: 400);
        }
        [HttpGet("anime/synopsis")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<OfferBasicResultDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult GetAnimeSynopsisOffer()
        {
            var resultAsync = _offerService.GetOfferAnimeSynopsis();
            resultAsync.Wait();
            var result = resultAsync.Result;
            if (result.Error == null)
            {
                return Ok(result.Result);
                //return CreatedAtAction(result.Result);
            }
            return Problem(result.Error.Message, statusCode: 400);
        }

        [HttpGet("anime/titles/{titleId}")]
        public IActionResult GetAnimeTitleOfferById(Guid titleId)
        {
            var resultAsync = _offerService.GetOfferAnimeTitleById(titleId);
            resultAsync.Wait();
            var result = resultAsync.Result;
            if (result.Error == null)
            {
                return Ok(result.Result);
            }
            return Problem(result.Error.Message, statusCode: 400);
        }

        [HttpPost("anime/{animeId}/titles")]
        public IActionResult CreateAnimeTitleOffer(Guid animeId, ProvidingTranslationOffer providingTranslationOffer)
        {
            var resultAsync = _offerService.CreateOfferAnimeTitle(animeId, providingTranslationOffer);
            resultAsync.Wait();
            var result = resultAsync.Result;
            if(result.Error == null)
            {
                return Ok(result.Result);
                //return CreatedAtAction(result.Result);
            }
            return Problem(result.Error.Message, statusCode: 400);
            //return BadRequest(result.Error);
        }

        [HttpGet("anime/synopsis/{titleId}")]
        public IActionResult GetAnimeSynopsisOfferById(Guid titleId)
        {
            var resultAsync = _offerService.GetOfferAnimeSynopsisById(titleId);
            resultAsync.Wait();
            var result = resultAsync.Result;
            if (result.Error == null)
            {
                return Ok(result.Result);
            }
            return Problem(result.Error.Message, statusCode: 400);
        }


        [HttpPost("anime/{animeId}/synopsis")]
        public IActionResult CreateAnimeSynopsisOffer(Guid animeId, ProvidingTranslationOffer providingTranslationOffer)
        {
            var resultAsync = _offerService.CreateOfferAnimeSynopsis(animeId, providingTranslationOffer);
            resultAsync.Wait();
            var result = resultAsync.Result;
            if (result.Error == null)
            {
                return Ok(result.Result);
                //return CreatedAtAction(result.Result);
            }
            return Problem(result.Error.Message, statusCode: 400);
            //return BadRequest(result.Error);
        }
    }
}
