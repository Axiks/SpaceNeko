using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.User.Library.Update;
using NekoSpace.API.Contracts.Models.UserService;
using NekoSpace.API.Contracts.Models.UserService.UserUpdates;
using NekoSpace.Core.Services.UserService;
using NekoSpace.Data;
using NekoSpace.Data.Models.User;
using System.Security.Claims;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal)
        {
            _userService = new UserService(dbContext, userManager, claimsPrincipal);
        }

        [HttpGet]
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
        }

    }
}
