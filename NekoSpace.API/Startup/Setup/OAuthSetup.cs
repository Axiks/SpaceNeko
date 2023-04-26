using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using System.Security.Claims;

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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtConfig.GetSymmetricSecurityKey(),
                        ValidateIssuer = false,
                        ValidIssuer = jwtConfig.validIssuer,
                        ValidateAudience = false,
                        ValidAudience = jwtConfig.validAudience,
                        ValidateLifetime = true,
                        RequireExpirationTime = false, // Only test!
                    };
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
