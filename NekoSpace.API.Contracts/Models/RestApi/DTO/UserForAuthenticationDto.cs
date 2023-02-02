using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.RestApi.DTO
{
    public class UserForAuthenticationDto
    {
        /*[Required(ErrorMessage = "Email is required."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }*/

        [Required(ErrorMessage = "Username is required."), MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
