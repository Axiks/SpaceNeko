using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Dto
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Email is required."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required"), Compare("Password", ErrorMessage = "The password and confirmation password do not match."), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Username is required."), MaxLength(50)]
        public string Username { get; set; }
    }
}
