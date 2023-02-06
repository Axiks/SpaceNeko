using NekoSpace.Core.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountService.Registration
{
    public class RegistrationResponse : AbstractResponseModel<bool>
    {
        public RegistrationResponse(bool result, string? error) : base(result, error)
        {
        }
    }
}
