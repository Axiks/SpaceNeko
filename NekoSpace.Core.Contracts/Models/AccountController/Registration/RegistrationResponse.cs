using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountController.Registration
{
    public class RegistrationResponse
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }

        public RegistrationResponse(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
    }
}
