using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.Account
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public required string RefreshToken { get; set; }
    }
}
