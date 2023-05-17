using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.User.Library.Update
{
    public class UpdateUserLibraryResult : AbstractResultModel<bool?>
    {
        public UpdateUserLibraryResult(bool? result, ErrorResultDTO? error) : base(result, error)
        {
        }
    }
}
