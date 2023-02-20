using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.UserService.User;
using NekoSpace.API.Contracts.Models.UserService.UserUpdates;
using NekoSpace.Core.Services.UserService;
using NekoSpace.Data;
using NekoSpace.Data.Models.User;
using System.Security.Claims;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeController : ControllerBase
    {
        private readonly UserService _userService;
        public MeController(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal)
        {
            _userService = new UserService(dbContext, userManager, claimsPrincipal);
        }

        [Authorize]
        [HttpGet()]
        public IActionResult GetMe()
        {
            var response = _userService.GetMe();
            response.Wait();
            return Ok(response.Result);
        }

        [Authorize]
        [HttpPost()]
        public IActionResult UpdateMe(UserUpdateCommand userUpdateCommand)
        {
            var response = _userService.UpdateMe(userUpdateCommand);
            response.Wait();
            return Ok(response.Result);
        }

        [Authorize]
        [HttpGet("Library")]
        public IActionResult GetLibrary()
        {
            var response = _userService.GetLibrary();
            response.Wait();
            return Ok(response.Result);
        }

        [Authorize]
        [HttpPost("Library")]
        public async Task<IActionResult> UpdateLibrary(UpdateLibraryCommand updateLibraryCommand)
        {
            var response = await _userService.UpdateLibraryAsync(updateLibraryCommand);
            if (response.Result == false)
            {
                return BadRequest(response.Error);
            }
            return Ok(response.Result);
        }

    }
}
