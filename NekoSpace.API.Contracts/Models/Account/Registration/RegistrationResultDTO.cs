using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Core.Contracts.Models.AccountService.Registration
{
    public class RegistrationResultDTO : AbstractResultDTO<TokenRequest>
    {
        public RegistrationResultDTO(TokenRequest? result, ProblemDetails? error) : base(result, error)
        {
        }

    }

}
