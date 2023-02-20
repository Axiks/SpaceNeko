using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.UserService.UserUpdates
{
    public class UpdateUserResult : AbstractResponseModel<bool?>
    {
        public UpdateUserResult(bool? result, string? error) : base(result, error)
        {
        }
    }
}
