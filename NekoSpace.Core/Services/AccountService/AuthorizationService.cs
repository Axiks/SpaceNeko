using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.Data.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NekoSpace.Core.Contracts.Models.AccountController.Login;
using NekoSpace.Core.Contracts.Models.AccountService.Registration;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using NekoSpace.API.General;
using NekoSpace.API.Contracts.Models.AccountService.Login;

namespace NekoSpace.Core.Services.AccountService
{
    public class AuthorizationService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly JwtConfig _jwtConfig;

        public AuthorizationService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, JwtConfig jwtConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig;
        }

        private bool isEmail(string text)
        {
            return text.Contains("@");
        }

        private string createNewToken(UserEntity user)
        {
            var userRoles = _userManager.GetRolesAsync(user);
            List<string> listRoles = userRoles.Result.ToList();

            string stringRoles = string.Join(",", listRoles);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, stringRoles)
            };
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtConfig.validIssuer,
                audience: _jwtConfig.validAudience,
                claims: userClaims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60 * 24)), // час дії 1 день
                signingCredentials: new SigningCredentials(_jwtConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return tokenString;
        }

        public async Task<LoginResponse> SignInAsync(LoginInput loginInput)
        {
            UserEntity user;
            if (isEmail(loginInput.Username))
            {
                user = await _userManager.FindByEmailAsync(loginInput.Username);
            }
            else
            {
                user = await _userManager.FindByNameAsync(loginInput.Username);
            }

            if (user == null)
            {
                return new LoginResponse(null, "No user found for this username or email");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginInput.Password, true, true);
            if (!result.Succeeded)
            {
                return new LoginResponse(null, "The password does not match");
            }

            string token = createNewToken(user);

            return new LoginResponse(token, null);
        }

        public async Task<bool> SignOutAsync()
        {
            _signInManager.SignOutAsync();
            return true;
        }

        public async Task<RegistrationResponse> RegistrationAsync(RegistrationInput registrationInput)
        {

            var user = new UserEntity
            {
                Email = registrationInput.Email,
                UserName = registrationInput.Username,

            };

            var result = await _userManager.CreateAsync(user, registrationInput.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return new RegistrationResponse(false, errors.ToString());
            }

            // Set User Role
            var setRoleResult = await _userManager.AddToRoleAsync(user, Roles.UserRole);
            if (!setRoleResult.Succeeded)
            {
                var errors = setRoleResult.Errors.Select(e => e.Description);
                return new RegistrationResponse(false, errors.ToString());
            }

            return new RegistrationResponse(true, null);
        }

    }
}
