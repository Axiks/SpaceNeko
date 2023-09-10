using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.Core.Helpers;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using System.Security.Claims;
using System.Text;

namespace NekoSpace.API.Startup.Setup
{
    public static class OAuthSetup
    {
        public static IServiceCollection RegisterOAuth(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.Configure<JwtConfig>(configurationManager.GetSection("JwtConfig"));

            JwtConfig jwtConfig = new JwtConfig(configurationManager["JwtConfig:Secret"])
            {
                validIssuer = configurationManager["JwtConfig:ValidIssuer"],
                validAudience = configurationManager["JwtConfig:ValidAudience"]
            };
            services.AddSingleton(jwtConfig);

            var tokenValidationParameter = new TokenValidationHelper(configurationManager).GetTokenValidationParameters();

            /*var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtConfig.GetSymmetricSecurityKey(),
                ValidateIssuer = false,
                ValidIssuer = jwtConfig.validIssuer, // for dev
                ValidateAudience = false, // fore dev
                ValidAudience = jwtConfig.validAudience,
                ValidateLifetime = true,
                RequireExpirationTime = false, // Only test!
            };*/

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameter;
                });

            services.AddAuthorization();

            services.AddTransient<ClaimsPrincipal>(s =>
                s.GetService<IHttpContextAccessor>().HttpContext.User);


            services.Configure<IdentityOptions>(opts => {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireDigit = true;
            });

            return services;
        }
    }
}
