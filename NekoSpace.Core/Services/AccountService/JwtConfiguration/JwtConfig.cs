using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NekoSpace.Core.Services.AccountService.JwtConfiguration
{
    public class JwtConfig
    {
        // private static string _secretKey;
        private string _secretKey;
        public string validIssuer { get; set; }
        public string validAudience { get; set; }

        public JwtConfig(string SecretKey)
        {
            _secretKey = SecretKey;
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }
    }
}
