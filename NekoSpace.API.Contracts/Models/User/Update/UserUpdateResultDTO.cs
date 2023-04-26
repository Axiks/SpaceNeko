using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.UserService
{
    public class UserUpdateResult : AbstractResultModel<bool?>
    {
        public UserUpdateResult(bool? result, ErrorResultDTO? error) : base(result, error)
        {
        }
    }
}
