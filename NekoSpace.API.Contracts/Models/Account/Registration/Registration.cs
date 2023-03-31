using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountService.Registration
{
    public class Registration
    {
        public Registration(string email, string password, string passwordConfirmation, string username)
        {
            Email = email;
            Password = password;
            PasswordConfirmation = passwordConfirmation;
            Username = username;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Username { get; set; }
    }
}
