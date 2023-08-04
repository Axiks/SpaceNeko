using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Core.Contracts.Models.AccountService.Registration
{
    public class RegistrationResultDTO : AbstractResultModel<RegistrationResultModel>
    {
        public RegistrationResultDTO(RegistrationResultModel? result, ErrorResultDTO? error) : base(result, error)
        {
        }

    }

    public class RegistrationResultModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }

}
