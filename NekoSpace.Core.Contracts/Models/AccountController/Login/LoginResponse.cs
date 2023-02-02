using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountController.Login
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }

        public LoginResponse(bool isSuccess, string? error, string? token)
        {
            IsSuccess = isSuccess;
            Error = error;
            Token = token;
        }
    }
}
