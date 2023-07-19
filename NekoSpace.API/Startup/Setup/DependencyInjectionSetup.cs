﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.Core.Services.AccountService.JwtConfiguration;
using NekoSpace.Data.Models.User;
using NekoSpace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using NekoSpace.Seed.Interfaces;
using NekoSpace.Seed;
using NekoSpace.API.Helpers;
using NekoSpace.Core.Services.DatabaseService;
using NekoSpace.ElasticSearch.Contracts.Interfaces;
using NekoSpace.ElasticSearch;
using Mapster;
using MapsterMapper;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;
using NekoSpace.Data.Contracts.Entities.General;
using NekoSpace.Repository.Contracts.Models;

namespace NekoSpace.API.Startup.Setup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            // services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.RegisterDatabase();

            /*services.AddScoped<ILog, FileLoger>(provider =>
            {
                return new FileLoger("log.txt") { };
            });*/

            //services.RegisterGraphQl();

            services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            //services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddProblemDetails();

            services.RegisterOAuth(configurationManager);

            services.RegisterCors();

            services.AddTransient<IElasticSearchRepository<ElasticSearchAnimeModel>, ElasticSearchAnimeRepository>();

            //services.AddElasticsearch(configurationManager);

            //services.AddScoped<ISeedAnsibleService, SeedAnsibleService>();
            //services.AddScoped<ISeedingService, SeedingService>();

            /*services.AddTransient<ISeedingService, SeedingService>((ctx) =>
            {
                ApplicationDbContext svc = ctx.GetService<ApplicationDbContext>();
                //IOtherService svc = ctx.GetRequiredService<IOtherService>();
                return new SeedingService(svc);
            });*/

            var config = new TypeAdapterConfig();

            config.NewConfig<AnimeEntity, ElasticSearchAnimeModel>()
                .Map(dest => dest.DBId, src => src.Id)
                .Map(dest => dest.ReleaseDatePeriod, src => src.Aired)
                .Map(dest => dest.Premiere, src => src.Premier);

            config.NewConfig<TextVariantSubItemEntity, ESMediaBasicTitleModel>()
                .Map(dest => dest.IsNative, src => src.IsMain);

            config.NewConfig<PremierEntity, ESPremiereModel>();

            config.NewConfig<AssociatedServiceEntity, InterconnectionLinkModel>()
                .Map(dest => dest.Id, src => src.ServiceId)
                .Map(dest => dest.ServiceName, src => src.ServiceName);


            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
