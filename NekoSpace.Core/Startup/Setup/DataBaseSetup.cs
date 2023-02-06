using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;

namespace NekoSpace.Core.Startup.Setup
{
    public static class DataBaseSetup
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services) {
            services.AddPooledDbContextFactory<ApplicationDbContext>(
            options => options.
                UseNpgsql("Server=postgres_db;Database=anilist_db;Username=neko;Password=mya", b => b.MigrationsAssembly("NekoSpace.Data"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(
                    Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information
                )
            );

            services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

            return services;
        }
    }
}
