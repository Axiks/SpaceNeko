using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NekoSpace.Core.Triggers;

namespace NekoSpace.API.Startup.Setup
{
    public static class DataBaseSetup
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(
            options => {
                options.UseNpgsql("Server=postgres_db;Database=anilist_db;Username=neko;Password=mya", b => b.MigrationsAssembly("NekoSpace.Data"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .LogTo(
                    Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information
                );
                /*options.UseTriggers(triggerOptions => {
                    triggerOptions.AddTrigger<AddMediaTrigger>();
                });*/
            }
                
            );

            services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

            return services;
        }
    }
}
