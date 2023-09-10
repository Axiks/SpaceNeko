using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.UserService
{
    public class UserUpdateResult : AbstractResultDTO<object?>
    {
        public UserUpdateResult(bool? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
