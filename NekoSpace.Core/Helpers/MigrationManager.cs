using AnimeDB;
using Microsoft.EntityFrameworkCore;

namespace NekoSpace.API.Helpers
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        //appContext.Database.Migrate();

                        appContext.Database.EnsureCreated();

                        // AutoUpdate DB
                        /*var updateDB = scope.ServiceProvider.GetRequiredService<IUpdateDB>();
                        updateDB.RunAsync();*/

                        //appContext.Seed();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
