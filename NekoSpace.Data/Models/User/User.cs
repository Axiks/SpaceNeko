using Microsoft.AspNetCore.Identity;

namespace NekoSpace.Data.Models.User
{
    public class NekoUser: IdentityUser
    {
        public string? About { get; set; }
    }
}
