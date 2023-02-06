using Microsoft.EntityFrameworkCore;
using NekoSpace.Data;

namespace NekoSpace.Core.Startup;

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

        //app.MigrateDatabase();

        return app;
    }
}
