using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.UserService.User
{
    public class UserUpdateResult : AbstractResponseModel<bool?>
    {
        public UserUpdateResult(bool? result, string? error) : base(result, error)
        {
        }
    }
}
