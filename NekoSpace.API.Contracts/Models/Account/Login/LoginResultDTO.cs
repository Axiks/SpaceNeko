using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.AccountService.Login
{
    public class LoginResultDTO : AbstractResultModel<string>
    {
        public LoginResultDTO(string? result, string? error) : base(result, error)
        {
        }
    }
}
