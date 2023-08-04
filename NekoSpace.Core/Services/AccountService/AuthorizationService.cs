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
using NekoSpace.API.Contracts.Abstract.General;
using System.Security.Cryptography;
using NekoSpace.Data.Contracts.Entities.User.OAuth;
using NekoSpace.Data;
using NekoSpace.API.Contracts.Models.Account;
using NekoSpace.Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace NekoSpace.Core.Services.AccountService
{
    public class AuthorizationService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly JwtConfig _jwtConfig;
        private ApplicationDbContext _dbContext;
        private ConfigurationManager _configurationManager;

        public AuthorizationService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, JwtConfig jwtConfig, ApplicationDbContext dbContext, ConfigurationManager configurationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig;
            _dbContext = dbContext;
            _configurationManager = configurationManager;
        }

        private bool isEmail(string text)
        {
            return text.Contains("@");
        }

        private JwtSecurityToken GenerateJwtToken(UserEntity user)
        {
            var userRoles = _userManager.GetRolesAsync(user);
            List<string> listRoles = userRoles.Result.ToList();

            string stringRoles = string.Join(",", listRoles);

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, stringRoles),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //var time = System.Configuration.ConfigurationManager.AppSettings["JwtConfig:ExpiryTimeFrame"];
            var time = DateTime.UtcNow.Add(TimeSpan.Parse(_configurationManager["JwtConfig:ExpiryTimeFrame"]));

            var jwtToken = new JwtSecurityToken(
                    issuer: _jwtConfig.validIssuer,
                    audience: _jwtConfig.validAudience,
                    claims: userClaims,
                    expires: time, // час дії
                    signingCredentials: new SigningCredentials(_jwtConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            //var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return jwtToken;
        }

        public async Task<LoginResultDTO> SignInAsync(Login loginInput)
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
                var errorResult = new ErrorResultDTO("No user found for this username or email");
                return new LoginResultDTO(null, errorResult);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginInput.Password, true, true);
            if (!result.Succeeded)
            {
                var errorResult = new ErrorResultDTO("The password does not match");
                return new LoginResultDTO(null, errorResult);
            }

            var jwtToken = GenerateJwtToken(user);
            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            string refreshTocken = ApplyRefreshToken(jwtToken);

            var lgm = new LoginResultModel {
                Token = token,
                RefreshToken = refreshTocken,
            };

            return new LoginResultDTO(lgm, null);
        }

        private string ApplyRefreshToken(JwtSecurityToken jwtToken)
        {
            var refreshToken = CreateNewRefreshToken(jwtToken);
            UpdateRefreshTocken(refreshToken);

            return refreshToken.Token;
        }

        private RefreshToken CreateNewRefreshToken(JwtSecurityToken token)
        {
            var jwtIdString = token.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var userId = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)), //Generaterefresh tocken
                JwtId = Guid.Parse(jwtIdString),
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(30),
                IsRevoked = false,
                IsUsed = false,
                UserId = userId
            };

            return refreshToken;
        }

        public async Task UpdateRefreshTocken(RefreshToken refreshToken)
        {
            var isUserExist = _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == refreshToken.UserId).Result != null;
            if (isUserExist)
            {
                _dbContext.RefreshTokens.Update(refreshToken);
            }
            else
            {
                _dbContext.RefreshTokens.AddAsync(refreshToken);
            }
            _dbContext.SaveChangesAsync();
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegistrationResultDTO> RegistrationAsync(Registration registrationInput)
        {

            var user = new UserEntity
            {
                Email = registrationInput.Email,
                UserName = registrationInput.Username,

            };

            var result = await _userManager.CreateAsync(user, registrationInput.Password);
            if (!result.Succeeded)
            {
                List<string> errors = result.Errors.Select(e => e.Description).ToList();
                var errorResult = new ErrorResultDTO(String.Join(", ", errors.ToArray()));
                return new RegistrationResultDTO(null, errorResult);
            }

            // Set User Role
            var setRoleResult = await _userManager.AddToRoleAsync(user, Roles.UserRole);
            if (!setRoleResult.Succeeded)
            {
                var errors = setRoleResult.Errors.Select(e => e.Description);
                var errorResult = new ErrorResultDTO(String.Join(", ", errors.ToArray()));
                return new RegistrationResultDTO(null, errorResult);
            }

            //SignIn
            var loginData = new Login(registrationInput.Username, registrationInput.Password);
            var signInResult = await SignInAsync(loginData);
            if(signInResult.Error != null) return new RegistrationResultDTO(null, new ErrorResultDTO("An error occurred while signing in"));

            return new RegistrationResultDTO(new RegistrationResultModel { Token = signInResult.Result.Token, RefreshToken = signInResult.Result.RefreshToken }, null);
        }

        public async Task<LoginResultDTO> VerefityAndGenerateToken(TokenRequest tokenRequest)
        {
            var tokenValidationParameter = new TokenValidationHelper(_configurationManager).GetTokenValidationParameters();

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken = null;
            try
            {
                var tokenInVerification = 
                    tokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameter, out validatedToken);


                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (result == false) return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));
                }

                var utcExpiryDate = long.Parse(tokenInVerification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);
                if(expiryDate <= DateTime.Now) return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));

                var storedToken = _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.Token == tokenRequest.RefreshToken).Result;
                if (storedToken == null) return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));

                if (storedToken.IsUsed) return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));

                if (storedToken.IsRevoked) return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));

                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                if (storedToken.JwtId.ToString() != jti) return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));

                var a = 

                if (storedToken.ExpiryDate < DateTime.UtcNow) return new LoginResultDTO(null, new ErrorResultDTO("Time expendet"));

                storedToken.IsUsed = true;


                _dbContext.RefreshTokens.Update(storedToken);
                await _dbContext.SaveChangesAsync();

                // Generate new tokens
                var dbUser = _userManager.FindByIdAsync(storedToken.UserId).Result;
                var jwtToken = GenerateJwtToken(dbUser);
                string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                string refreshTocken = ApplyRefreshToken(jwtToken);

                var lgm = new LoginResultModel
                {
                    Token = token,
                    RefreshToken = refreshTocken,
                };

                return new LoginResultDTO(lgm, null);

            }
            catch (SecurityTokenException se)
            {
                var x = se;
                return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite"));
            }
            catch (Exception e)
            {
                //log(e.ToString()); //something else happened
                throw;
            }
            //... manual validations return false if anything untoward is discovered
            return new LoginResultDTO(null, new ErrorResultDTO("ErrorNeedWrite...When i can see true.. all is ok"));
        }

        // Helper section
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

    }
}
