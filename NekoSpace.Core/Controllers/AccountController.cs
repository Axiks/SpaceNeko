using AnimeDB;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.API.Configuration;
using NekoSpace.API.Contracts.Models.RestApi.DTO;
using NekoSpace.API.Contracts.Models.RestApi.Response;
using NekoSpace.API.General;
using NekoSpace.Core.Contracts.Models.AccountController.Login;
using NekoSpace.Core.Contracts.Models.AccountController.Registration;
using NekoSpace.Data.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreAccountController = NekoSpace.Core.Services.AccountController.AccountController;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private CoreAccountController _coreAccountController;
        public AccountController(UserManager<NekoUser> userManager, SignInManager<NekoUser> signInManager, JwtConfig jwtConfig)
        {
            _coreAccountController = new CoreAccountController(userManager, signInManager, jwtConfig);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(UserForAuthenticationDto userForAuthenticationDto)
        {
            LoginInput loginInput = new LoginInput(
                userForAuthenticationDto.Username,
                userForAuthenticationDto.Password,
                userForAuthenticationDto.RememberMe
             );
            var resultAsync = _coreAccountController.SignInAsync(loginInput);

            resultAsync.Wait();

            if (resultAsync.IsCompleted)
            {
                var result = resultAsync.Result;

                if (!result.IsSuccess)
                {
                    return BadRequest(result.Error);
                }

                return Ok(new JWTTokenResponse
                {
                    Token = result.Token
                });
            }

            return BadRequest("Undefined");
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            RegistrationInput registrationInput = new RegistrationInput(
                    userForRegistration.Email,
                    userForRegistration.Password,
                    userForRegistration.ConfirmPassword,
                    userForRegistration.Username
                );

            var resultAsync = _coreAccountController.RegistrationAsync(registrationInput);
            resultAsync.Wait();

            if (resultAsync.IsCompleted)
            {
                var result = resultAsync.Result;

                if (!result.IsSuccess)
                {
                    return BadRequest(result.Error);
                }

                return StatusCode(201);
            };

            return BadRequest("Undefined");
        }

        [Authorize]
        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOutAsync()
        {
            var resultAsync = _coreAccountController.SignOutAsync();
            resultAsync.Wait();

            if (resultAsync.IsCompleted) {
                var result = resultAsync.Result;

                return result ? Ok("User logout success!") : BadRequest("User logout unsuccess!");
            }

            return BadRequest();
        }
    }
}
