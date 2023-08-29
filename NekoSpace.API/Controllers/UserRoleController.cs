using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Core.Services.UserService;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Annotations;
using MapsterMapper;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.API.General;

namespace NekoSpace.API.Controllers
{
    [Route("api/User/{id}/roles")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private readonly UserService _userService;
        public UserRoleController(ApplicationDbContext dbContext, UserManager<UserEntity> userManager, ClaimsPrincipal claimsPrincipal, IMapper mapper)
        {
            _userService = new UserService(dbContext, userManager, claimsPrincipal, mapper);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Authorize(Roles = Roles.AdministratorRole)]
        [Authorize(Roles = Roles.ModeratorRole)]
        public async Task<IActionResult> AddRole(
        [FromRoute] Guid id,  // <---- new parameter
        [FromBody] List<Role> roles)
        {
            foreach (Role role in roles) {
                _userService.AddRole(id, role);
            }
            return Ok();
        }

        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Authorize(Roles = Roles.AdministratorRole)]
        [Authorize(Roles = Roles.ModeratorRole)]
        public async Task<IActionResult> DeleteRole(
        [FromRoute] Guid id,  // <---- new parameter
        [FromBody] List<Role> roles)
        {
            foreach (Role role in roles)
            {
                _userService.RemoveRole(id, role);
            }
            return Ok();
        }
    }
}
