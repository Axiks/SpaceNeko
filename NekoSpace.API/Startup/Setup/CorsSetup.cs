﻿using Microsoft.Extensions.DependencyInjection;

namespace NekoSpace.API.Startup.Setup
{
    public static class CorsSetup
    {
        public static IServiceCollection RegisterCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(name: "allowedOrigin",
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:3000",
                                "https://localhost:3000",
                                "http://localhost:2083",
                                "https://localhost:2083",
                                "http://neko3.space",
                                "https://neko3.space",
                                "http://web.neko3.space",
                                "https://web.neko3.space",
                                "http://dev.neko3.space",
                                "https://dev.neko3.space"
                                )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        }
                    );
            });

            return services;
        }
    }
}
