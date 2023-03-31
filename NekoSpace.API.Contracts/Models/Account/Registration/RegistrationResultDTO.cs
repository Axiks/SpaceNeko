using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountService.Registration
{
    public class RegistrationResultDTO : AbstractResultModel<bool>
    {
        public RegistrationResultDTO(bool result, string? error) : base(result, error)
        {
        }
    }
}
