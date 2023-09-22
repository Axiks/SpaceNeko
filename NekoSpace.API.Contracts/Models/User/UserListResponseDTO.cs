using Microsoft.AspNetCore.Mvc;
using NekoSpace.API.Contracts.Abstract.General;

namespace NekoSpace.API.Contracts.Models.User
{
    public class UserListResponseDTO : AbstractResultDTO<UserListResponse>
    {
        public UserListResponseDTO(UserListResponse? result, ProblemDetails? error) : base(result, error)
        {
        }
    }

    public class UserListResponse
    {
        public int numberOfUsers { get; set; }   
        public List<UserResponse> users { get; set; }
    }
}
