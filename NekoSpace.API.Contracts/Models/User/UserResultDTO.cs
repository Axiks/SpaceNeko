using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;
using NekoSpace.API.Contracts.Models.User;

namespace NekoSpace.API.Contracts.Models.UserService
{
    public class UserResultDTO : AbstractResultDTO<UserResponse>
    {
        public UserResultDTO(UserResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }
}
