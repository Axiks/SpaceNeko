using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;
using NekoSpace.Log.Interface;
using NekoSpace.Log;
using Microsoft.EntityFrameworkCore;

namespace NekoSpace.Core.Startup.Setup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.RegisterDatabase();

            services.AddScoped<ILog, FileLoger>(provider =>
            {
                return new FileLoger("log.txt") { };
            });

            //services.RegisterGraphQl();

            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.RegisterOAuth(configurationManager);

            services.RegisterCors();

            return services;
        }
    }
}
