using AnimeDB;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.API.Configuration;
using NekoSpace.API.Dto;
using NekoSpace.API.DTO;
using NekoSpace.API.General;
using NekoSpace.Data.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<NekoUser> _userManager;
        private readonly SignInManager<NekoUser> _signInManager;
        private readonly JwtConfig _jwtConfig;
        public AccountController(UserManager<NekoUser> userManager, SignInManager<NekoUser> signInManager, JwtConfig jwtConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig;

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(UserForAuthenticationDto userForAuthenticationDto)
        {
            /*if (userForAuthenticationDto is null)
            {
                return BadRequest("Invalid user request!!!");
            }*/

            NekoUser user;
            if (userForAuthenticationDto.Username.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(userForAuthenticationDto.Username);
            }
            else
            {
                user = await _userManager.FindByNameAsync(userForAuthenticationDto.Username);
            }
            if (user == null)
            {
                //return BadRequest(new RegistrationResponseDto { Errors = new string["Login, ", ""]  });
                return BadRequest("The user was not found");
            }
            var result = await
            _signInManager.PasswordSignInAsync(user, userForAuthenticationDto.Password, userForAuthenticationDto.RememberMe, true);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var userRoles = _userManager.GetRolesAsync(user);
            List<string> listRoles = userRoles.Result.ToList();
            //string stringRoles = "";
            /*if (userRoles.IsCompleted)
            {
                stringRoles = userRoles.ToString();
            }*/

            string stringRoles = string.Join(",", listRoles);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, stringRoles)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtConfig.validIssuer,
                audience: _jwtConfig.validAudience,
                claims: userClaims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60*24)), // час дії 1 день
                signingCredentials: new SigningCredentials(_jwtConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return Ok(new JWTTokenResponse
            {
                Token = tokenString
            });
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            //var user = _mapper.Map<NekoUser>(userForRegistration);

            var user = new NekoUser { 
                Email = userForRegistration.Email,
                UserName = userForRegistration.Username,
                
            };

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponse { Errors = errors });
            }

            // Set User Role
            var setRoleResult = await _userManager.AddToRoleAsync(user, Roles.UserRole);
            if (!setRoleResult.Succeeded)
            {
                var errors = setRoleResult.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponse { Errors = errors });
            }

            return StatusCode(201);
        }

        [Authorize]
        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOutAsync()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email); // will give the user's Email
            return Ok("User: " + userEmail + " Logout success!");

            /*var user = _userManager.GetUserAsync(HttpContext.User);
            if (user.IsCompleted)
            {
                if ()
                {
                    string username = user.Result.UserName;

                }

                await _signInManager.SignOutAsync();
                return Ok("User: " + username + " Logout success!");

            }

            return BadRequest(); //test*/
        }
    }
}
