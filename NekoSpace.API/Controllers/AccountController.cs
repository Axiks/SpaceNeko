using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.AccountService.Login;
using NekoSpace.Core.Contracts.Models.AccountController.Login;
using NekoSpace.Core.Contracts.Models.AccountService.Registration;
using NekoSpace.Core.Services.AccountService;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using NekoSpace.Data.Models.User;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(LoginResultModel))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> SignInAsync(Login userLoginData)
        {
            var task = _authorizationService.SignInAsync(userLoginData);
            task.Wait();
            var result = task.Result;

            if(result.Error == null)
            {
                return Ok();
            }

            /* var problemDetails = new ProblemDetails
             {
                 Detail = "The request parameters failed to validate.",
                 Instance = null,
                 Status = 401,
                 Title = "Validation Error",
                 Type = "https://example.net/validation-error",
             };

             problemDetails.Extensions.Add("errors", new List<ValidationProblemDetailsParam>()
             {
                 new("name", "Cannot be blank."),
                 new("age", "Must be great or equals to 18.")
             });

             return new ObjectResult(problemDetails)
             {
                 StatusCode = 401
             };*/
            //return Unauthorized();

            return Problem(
                result.Error.Message,
                null,
                401,
                "Unauthorized",
                null);
        }

        public class ValidationProblemDetailsParam
        {
            public ValidationProblemDetailsParam(string name, string reason)
            {
                Name = name;
                Reason = reason;
            }

            public string Name { get; set; }
            public string Reason { get; set; }
        }

        [HttpPost("Registration")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(RegistrationResultModel))] 
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(ErrorResultDTO))]
        public async Task<IActionResult> RegisterAsync([FromBody] Registration userRegistrationData)
        {
            var task = _authorizationService.RegistrationAsync(userRegistrationData);
            task.Wait();
            var result = task.Result;

            if (result.Error == null)
            {
                return Ok(result.Result);
            }
            return Unauthorized(result.Error); // Fix
        }

        [Authorize]
        [HttpPost("SignOut")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
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
