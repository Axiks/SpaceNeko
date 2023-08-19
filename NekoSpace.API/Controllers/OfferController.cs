using Microsoft.AspNetCore.Mvc;
using NekoSpace.Data;
using System.Security.Claims;
using NekoSpace.Core.Services.OfferController;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.ElasticSearch;
using NekoSpace.Repository.Repositories.Media;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;
using MapsterMapper;
using NekoSpace.API.Contracts.Models.Offer.Request.Update;
using NekoSpace.API.Contracts.Models.Offer.Response;
using NekoSpace.API.Contracts.Models.Offer.Request.Get;
using NekoSpace.API.Contracts.Models.Offer.Request.Decision;
using NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferController : ControllerBase
    {
        private readonly OfferService _offerService;
        public OfferController(ClaimsPrincipal claimsPrincipal, ApplicationDbContext dbContext, AbstractMediaRepository<MediaEntity, ElasticSearchMediaBasicModel> mediaRepository, IConfiguration configuration, IMapper mapper)
        {
            _offerService = new OfferService(claimsPrincipal, dbContext, mediaRepository, configuration, mapper);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicOfferResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult CreateOffer([SwaggerRequestBody] OfferBasicRequest offerRequest)
        {

            if (offerRequest is TitleOfferRequest)
            {
                TitleOfferRequest offer = offerRequest as TitleOfferRequest;
                var reultResponse = _offerService.CreateTitleOffer(offer).Result;

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
                var reultResponse = _offerService.CreateSynopsisOffer(offer).Result;

                if (reultResponse.Result != null)
                {
                    return Ok(reultResponse.Result);
                }

                if (reultResponse.Error != null)
                {
                    return new ObjectResult(reultResponse.Error);
                }
            }
            else if (offerRequest is PosterOfferRequest)
            {
                PosterOfferRequest offer = offerRequest as PosterOfferRequest;
            }

            return Ok();
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicOfferResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult UpdateOffer([SwaggerRequestBody] UpdateBasicOfferRequest offerRequest)
        {

            if (offerRequest is UpdateTitleOfferRequest)
            {
                UpdateTitleOfferRequest offer = offerRequest as UpdateTitleOfferRequest;
                var reultResponse = _offerService.UpdateTitleOffer(offer).Result;

                if (reultResponse.Result != null)
                {
                    return Ok(reultResponse.Result);
                }

                if (reultResponse.Error != null)
                {
                    return new ObjectResult(reultResponse.Error);
                }
            }
            else if (offerRequest is UpdateDescriptionOfferRequest)
            {
                UpdateDescriptionOfferRequest offer = offerRequest as UpdateDescriptionOfferRequest;
                var reultResponse = _offerService.UpdateSynopsisOffer(offer).Result;

                if (reultResponse.Result != null)
                {
                    return Ok(reultResponse.Result);
                }

                if (reultResponse.Error != null)
                {
                    return new ObjectResult(reultResponse.Error);
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(DeleteOfferResponseDTO))]
        public IActionResult DeleteOffer(Guid id)
        {
            var reultResponse = _offerService.DeleteOffer(id).Result;

            if (reultResponse.Result != null)
            {
                return Ok(reultResponse.Result);
            }

            if (reultResponse.Error != null)
            {
                return new ObjectResult(reultResponse.Error);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicOfferResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]

        public IActionResult GetOffer(Guid id)
        {
            var reultResponse = _offerService.GetOffer(id).Result;
            if(reultResponse.Result != null) { return Ok(reultResponse.Result); }
            return NotFound();
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicListOfferResult<BasicOfferResponse>))]
        public IActionResult GetAllOffer([FromQuery] GetOfferListRequest request)
        {
            var reultResponse = _offerService.GetAllOffer(request).Result;
            return Ok(reultResponse.Result);
        }

/*        [HttpPut("{id}/decision")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicOfferResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult MakeDecision(Guid id, [SwaggerRequestBody] UpdateOfferDecisionRequest offerBasicRequest)
        {
            var reultResponse = _offerService.MakeDecision(id, offerBasicRequest).Result;
            //UpdateOfferDecisionResponseDTO

            if (reultResponse.Result != null)
            {
                return Ok(reultResponse.Result);
            }

            if (reultResponse.Error != null)
            {
                return new ObjectResult(reultResponse.Error);
            }

            return Ok();
        }*/

        /*[HttpGet("anime/titles")]
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
            var resultAsync = _offerService.CreateOfferAnimeTitle(animeId, providingTranslationOffer);
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
