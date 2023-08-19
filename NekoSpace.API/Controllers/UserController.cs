using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Offer.Response.Basic;
using NekoSpace.API.Contracts.Models.Offer.Response.BasicDTO;
using NekoSpace.API.Contracts.Models.User;
using NekoSpace.API.Contracts.Models.User.Library.Update;
using NekoSpace.API.Contracts.Models.UserService;
using NekoSpace.API.Contracts.Models.UserService.UserUpdates;
using NekoSpace.Core.Services.UserService;
using NekoSpace.Data;
using NekoSpace.Data.Models.User;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal, IMapper mapper)
        {
            _userService = new UserService(dbContext, userManager, claimsPrincipal, mapper);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserListResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public IActionResult GetAllUsers()
        {
            var resultResponse = _userService.GetAllUsers().Result;
            if (resultResponse.Error != null)
            {
                return new ObjectResult(resultResponse.Error);
            }

            return Ok(resultResponse.Result);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]

        public IActionResult GetUser(Guid id)
        {
            var resultResponse = _userService.GetUser(id).Result;

            if (resultResponse.Error != null)
            {
                return new ObjectResult(resultResponse.Error);
            }

            return Ok(resultResponse.Result);
        }

        [HttpGet("{id}/offers")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(BasicListOfferResult<BasicOfferResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]

        public IActionResult GetUserOffer(Guid id)
        {
            var reultResponse = _userService.GetUserOffers(id).Result;

            if (reultResponse.Error != null)
            {
                return new ObjectResult(reultResponse.Error);
            }

            return Ok(reultResponse.Result);
        }

        /*[HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var response = _userService.GetMe();
            return Ok(response.Result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMe(UserUpdateCommand userUpdateCommand)
        {
            var response = _userService.UpdateMe(userUpdateCommand);
            return Ok(response.Result);
        }

        [HttpGet("Library")]
        public async Task<IActionResult> GetLibrary()
        {
            var response = await _userService.GetLibrary();
            return Ok(response);
        }

        [HttpPost("Library")]
        public async Task<IActionResult> UpdateLibrary(UpdateUserLibrary updateLibraryCommand)
        {
            var response = await _userService.UpdateLibraryAsync(updateLibraryCommand);
            if (response.Result == false)
            {
                return BadRequest(response.Error);
            }
            return Ok(response.Result);
        }*/

    }
}
