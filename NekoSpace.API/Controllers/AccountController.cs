using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Core.Contracts.Models.AccountController.Login;
using NekoSpace.Core.Contracts.Models.AccountService.Registration;
using NekoSpace.Core.Services.AccountService;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using NekoSpace.Data.Models.User;
using System.Security.Claims;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AuthorizationService _authorizationService;
        public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, ClaimsPrincipal claimsPrincipal, JwtConfig jwtConfig)
        {
            _authorizationService = new AuthorizationService(userManager, signInManager, jwtConfig);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(Login userLoginData)
        {
            var task = _authorizationService.SignInAsync(userLoginData);
            task.Wait();
            var result = task.Result;

            if(result.Error == null)
            {
                return Ok(result.Result);
            }
            return Unauthorized(result.Error);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterAsync([FromBody] Registration userRegistrationData)
        {
            var task = _authorizationService.RegistrationAsync(userRegistrationData);
            task.Wait();
            var result = task.Result;

            if (result.Error == null)
            {
                return Ok(result.Result);
            }
            return Unauthorized(result.Error);
        }

        [Authorize]
        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOutAsync(CancellationToken ct)
        {
            try
            {
                await _authorizationService.SignOutAsync();
                return Ok();
            }
            catch (TaskCanceledException cte) {
                throw;
            }
        }
    }
}
