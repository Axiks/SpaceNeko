using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Account;
namespace NekoSpace.API.Contracts.Models.AccountService.Login
{
    public class LoginResultDTO : AbstractResultDTO<TokenRequest>
    {
        public LoginResultDTO(TokenRequest? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
