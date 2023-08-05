using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;

namespace NekoSpace.API.Contracts.Models.UserService
{
    public class UserResultDTO : AbstractResultDTO<UserGetResponse>
    {
        public UserResultDTO(UserGetResponse? result, ProblemDetails? error) : base(result, error)
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
