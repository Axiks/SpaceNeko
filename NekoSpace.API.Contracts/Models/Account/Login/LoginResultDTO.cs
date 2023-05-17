using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.AccountService.Login
{
    public class LoginResultDTO : AbstractResultModel<LoginResultModel>
    {
        public LoginResultDTO(LoginResultModel? result, ErrorResultDTO? error) : base(result, error)
        {
        }
    }

    public class LoginResultModel
    {
        [Required]
        public string token { get; set; }

        public LoginResultModel(string token)
        {
            token = token;
        }
    }
}
