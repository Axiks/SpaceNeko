using NekoSpace.API.Contracts.Abstract.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Models.AccountService.Login
{
    public class LoginResultDTO : AbstractResultModel<LoginResultModel>
    {
        public LoginResultDTO(LoginResultModel? result, ErrorResultDTO? error) : base(result, error)
        {
        }
    }

    public class LoginResultModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public required string RefreshToken { get; set; }
    }
}
