using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using NekoSpace.API.Helpers;
using NekoSpace.Data;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.Startup;

public static class SeedConfiguration
{
    public static WebApplication ConfigureSeed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                //context.Database.Migrate();
                context.Database.EnsureCreated();
            }
        }

        app.MigrateDatabase();

        return app;
    }
}
