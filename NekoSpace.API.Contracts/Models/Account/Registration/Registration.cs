using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/
",
         ErrorMessage = "The email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
         ErrorMessage = "Password must contain a minimum of 8 characters, including upper and lower case letters, numbers and symbols")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
         ErrorMessage = "Password must contain a minimum of 8 characters, including upper and lower case letters, numbers and symbols")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordConfirmation { get; set; }
        
        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string Username { get; set; }
    }
}
