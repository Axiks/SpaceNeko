using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;

namespace NekoSpace.Core.Startup.Setup
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

            return services;
        }
    }
}
