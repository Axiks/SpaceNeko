using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Models.Account;
using NekoSpace.API.Contracts.Models.AccountService.Login;
using NekoSpace.Core.Contracts.Models.AccountController.Login;
using NekoSpace.Core.Contracts.Models.AccountService.Registration;
using NekoSpace.Core.Services.AccountService;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using NekoSpace.Data;
using NekoSpace.Data.Models.User;
using Nest;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AuthorizationService _authorizationService;
        public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, JwtConfig jwtConfig, ApplicationDbContext applicationDbContext, ConfigurationManager configurationManager)
        {
            _authorizationService = new AuthorizationService(userManager, signInManager, jwtConfig, applicationDbContext, configurationManager);
        }

        [HttpPost("SignIn")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TokenRequest))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> SignInAsync(Login userLoginData)
        {
            var response = _authorizationService.SignInAsync(userLoginData).Result;
            if (response.Error != null) return new ObjectResult(response.Error);

            return Ok(response.Result);
        }


        [HttpPost("Registration")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TokenRequest))]
        [SwaggerResponse(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> RegisterAsync([FromBody] Registration userRegistrationData)
        {
            var response = _authorizationService.RegistrationAsync(userRegistrationData).Result;

            if (response.Error != null) return new ObjectResult(response.Error);

            return Ok(response.Result);
        }

        [Authorize]
        [HttpPost("SignOut")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> SignOutAsync(CancellationToken ct)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _authorizationService.SignOutAsync(userId);

            return Ok();
        }


        [HttpPost("RefreshToken")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TokenRequest))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> RefreshTockenAsync([FromBody] TokenRequest tokenRefresh)
        {
                var res = await _authorizationService.VerefityAndGenerateToken(tokenRefresh);

                if(res.Result == null) {
                    return new ObjectResult(res.Error);
                }

                return Ok(res.Result);
        }

    }
}
