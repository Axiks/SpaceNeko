using Microsoft.IdentityModel.Tokens;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;

namespace NekoSpace.Core.Helpers;

public class TokenValidationHelper
{
    private static JwtConfig jwtConfig; 

    public TokenValidationHelper(ConfigurationManager configurationManager)
    {
        jwtConfig = new JwtConfig(configurationManager["JwtConfig:Secret"])
        {
            validIssuer = configurationManager["JwtConfig:ValidIssuer"],
            validAudience = configurationManager["JwtConfig:ValidAudience"]
        };
    }


    public TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = jwtConfig.GetSymmetricSecurityKey(),
            ValidateIssuer = false,
            ValidIssuer = jwtConfig.validIssuer, // for dev
            ValidateAudience = false, // fore dev
            ValidAudience = jwtConfig.validAudience,
            ValidateLifetime = true,
            RequireExpirationTime = false, // Only test!
        };
    }
}
