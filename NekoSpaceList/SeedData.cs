using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.General;
using NekoSpace.Data.Models.User;

namespace NekoSpace.API
{
    public class SeedData
    {
        public SeedData()
        {
        }

        public async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services
                .GetRequiredService<UserManager<NekoUser>>();
            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Administrator
            var alreadyExistsAdministratorRole = await roleManager
                .RoleExistsAsync(Roles.AdministratorRole);

            if (!alreadyExistsAdministratorRole) {
                await roleManager.CreateAsync(
                new IdentityRole(Roles.AdministratorRole));
            }

            // Moderator
            var alreadyExistsModeratorRole = await roleManager
                .RoleExistsAsync(Roles.ModeratorRole);

            if (!alreadyExistsModeratorRole)
            {
                await roleManager.CreateAsync(
                new IdentityRole(Roles.ModeratorRole));
            }

            // Moderator
            var alreadyExistsCreatorRole = await roleManager
                .RoleExistsAsync(Roles.CreatorRole);

            if (!alreadyExistsCreatorRole)
            {
                await roleManager.CreateAsync(
                new IdentityRole(Roles.CreatorRole));
            }

            // User
            var alreadyExistsUserRole = await roleManager
                .RoleExistsAsync(Roles.UserRole);

            if (!alreadyExistsUserRole)
            {
                await roleManager.CreateAsync(
                new IdentityRole(Roles.UserRole));
            }

            // Guest
            var alreadyExistsGuestRole = await roleManager
                .RoleExistsAsync(Roles.GuestRole);

            if (!alreadyExistsGuestRole)
            {
                await roleManager.CreateAsync(
                new IdentityRole(Roles.GuestRole));
            }

        }

        private static async Task EnsureTestAdminAsync(UserManager<NekoUser> userManager)
        {
            var userAdminExist = userManager.FindByNameAsync("Admin").Result != null;

            if (userAdminExist == true) return;

            var testAdmin = new NekoUser
            {
                UserName = "Admin",
                Email = "admin@example.local"
            };

            await userManager.CreateAsync(testAdmin, "Pass123!!!");
            await userManager.AddToRoleAsync(testAdmin, Roles.AdministratorRole);
        }
    }
}
