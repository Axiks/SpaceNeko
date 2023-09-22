using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;

namespace NekoSpace.API.Startup.Setup
{
    public static class DataBaseSetup
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            string dbName = configurationManager["PGDatabase:DatabaseName"];
            string dbUsername = configurationManager["PGDatabase:Username"];
            string dbPassword = configurationManager["PGDatabase:Password"];

            services.AddPooledDbContextFactory<ApplicationDbContext>(
            options =>
            {
                options.UseNpgsql(String.Format("Server=postgres_db;Database={0};Username={1};Password={2}", dbName, dbUsername, dbPassword), b => b.MigrationsAssembly("NekoSpace.Data"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(
                    Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information
                );
            }
            );
            services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

            return services;
        }
    }
}
