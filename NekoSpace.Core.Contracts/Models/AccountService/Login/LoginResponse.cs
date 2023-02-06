using NekoSpace.Core.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountController.Login
{
    public class LoginResponse : AbstractResponseModel<string>
    {
        public LoginResponse(string? result, string? error) : base(result, error)
        {
        }
    }
}
