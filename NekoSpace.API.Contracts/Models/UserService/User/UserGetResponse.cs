using NekoSpace.API.Contracts.Abstract.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.UserService.User
{
    public class UserGetResult : AbstractResponseModel<UserGetResponse>
    {
        public UserGetResult(UserGetResponse? result, string? error) : base(result, error)
        {
        }
    }

    public class UserGetResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string About { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
