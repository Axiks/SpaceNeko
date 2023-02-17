using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.RestApi.DTO
{
    public class UserForAuthenticationDto
    {

        [Required(ErrorMessage = "Username is required."), MaxLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
