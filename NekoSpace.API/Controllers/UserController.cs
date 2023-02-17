using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.UserService.UserUpdates;
using NekoSpace.Core.Services.AccountService;
using NekoSpace.Data;
using NekoSpace.Data.Models.User;
using System.Security.Claims;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserService _userService;
        public UserController(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal)
        {
            _dbContext = dbContext;
            _userService = new UserService(dbContext, userManager, claimsPrincipal);
        }

        [Authorize]
        [HttpGet("GetUserUpdates")]
        public IActionResult GetUserUpdates()
        {
            var u = _userService.GetMediaUpdates();
            u.Wait();
            return Ok();
        }

        // Get Me

        // Update user libraty
        [Authorize]
        [HttpPost("UpdateLibrary")]
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
