using Microsoft.AspNetCore.Mvc;
using NekoSpace.Data;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Annotations;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request;
using NekoSpace.Core.Services.OfferService;
using NekoSpaceList.Models.Anime;
using NekoSpace.Core.Services.AnimeService;
using NekoSpace.API.Contracts.Models.Offer.Response;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 /*   [Authorize]*/
    public class OffersController : ControllerBase
    {
        private readonly OfferTtileService<AnimeEntity> _offerService;
        public OffersController(ClaimsPrincipal claimsPrincipal, ApplicationDbContext dbContext)
        {
            _offerService = new OfferTtileService<AnimeEntity>(claimsPrincipal, dbContext);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicOfferResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult CreateOffer([SwaggerRequestBody] OfferBasicRequest offerRequest)
        {

            if (offerRequest is TitleOfferRequest)
            {
                TitleOfferRequest offer = offerRequest as TitleOfferRequest;
                var reultResponse = _offerService.CreateOffer(offer).Result;

                if (reultResponse.Result != null)
                {
                    return Ok(reultResponse.Result);
                }

                if (reultResponse.Error != null)
                {
                    return new ObjectResult(reultResponse.Error);
                }
            }
            else if (offerRequest is DescriptionOfferRequest)
            {
                DescriptionOfferRequest offer = offerRequest as DescriptionOfferRequest;
            }
            else if (offerRequest is PosterOfferRequest)
            {
                PosterOfferRequest offer = offerRequest as PosterOfferRequest;
            }

            return Ok();
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<ProvidingTranslationOffertResultDTO>))]
        public IActionResult AllTitleOffers()
        {
            var reultResponse = _offerService.GetOffers();
            return Ok(reultResponse);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public IActionResult UpdateOffer(Guid id, [SwaggerRequestBody] TitleOfferRequest offerRequest)
        {
            var reultResponse = _offerService.UpdateOffer(offerRequest);
            return Ok(reultResponse);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DeleteOfferResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult DeleteOffer(Guid id)
        {
            var reultResponse = _offerService.DeleteOffer(id).Result;
            if (reultResponse.Result != null)
            {
                return Ok(reultResponse.Result);
            }

            return new ObjectResult(reultResponse.Error);
        }



        /* [HttpGet("anime/titles")]
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
             return Problem(result.Error.Title, statusCode: 400);
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
             return Problem(result.Error.Title, statusCode: 400);
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
             return Problem(result.Error.Title, statusCode: 400);
         }

         [HttpPost("anime/{animeId}/titles")]
         public IActionResult CreateAnimeTitleOffer(Guid animeId, ProvidingTranslationOffer providingTranslationOffer)
         {
             var resultAsync = _offerService.CreateOffer(animeId, providingTranslationOffer);
             resultAsync.Wait();
             var result = resultAsync.Result;
             if(result.Error == null)
             {
                 return Ok(result.Result);
                 //return CreatedAtAction(result.Result);
             }
             return Problem(result.Error.Title, statusCode: 400);
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
             return Problem(result.Error.Title, statusCode: 400);
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
             return Problem(result.Error.Title, statusCode: 400);
             //return BadRequest(result.Error);
         }*/
    }
}
