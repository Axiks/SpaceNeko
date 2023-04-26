using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountController.Login
{
    public class Login
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
         ErrorMessage = "Password must contain a minimum of 8 characters, including upper and lower case letters, numbers and symbols")]
        public string Password { get; set; }
    }
}
