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
            ValidateIssuer = true,
            ValidIssuer = jwtConfig.validIssuer, // for dev
            ValidateAudience = true, // fore dev
            ValidAudience = jwtConfig.validAudience,
            ValidateLifetime = true,
            RequireExpirationTime = true, // Only test!
        };
    }
}
