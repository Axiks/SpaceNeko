using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.Account
{
    public class TokenRequest
    {
        [Required]
        public string AccessToken { get; set; }

        [Required]
        public required string RefreshToken { get; set; }
    }
}
