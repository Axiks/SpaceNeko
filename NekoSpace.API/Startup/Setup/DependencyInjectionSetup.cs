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
using NekoSpace.Repository;
using NekoSpace.Repository.Repositories;
using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Core.Services.AnimeService;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using JsonSubTypes;
using NekoSpace.API.Contracts.Models.ProvidingTranslationOffer.Request;
using NekoSpace.Common.Enums.API;
using Newtonsoft.Json.Converters;
using NekoSpace.ElasticSearch.Contracts.General;

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

            /* services.AddControllers().AddJsonOptions(x =>
             {
                 // serialize enums as strings in api responses (e.g. Role)
                 x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             });*/

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Register the subtypes of the Device (Phone and Laptop)
                //and define the device Discriminator
                options.SerializerSettings.Converters.Add(
                    JsonSubtypesConverterBuilder
                    .Of(typeof(OfferBasicRequest), "OfferType")
                    .RegisterSubtype(typeof(TitleOfferRequest), OfferType.Title)
                    .RegisterSubtype(typeof(DescriptionOfferRequest), OfferType.Description)
                    .SerializeDiscriminatorProperty()
                    .Build()
                );
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddSwaggerGenNewtonsoftSupport();

            //services.ConfigureHttpJsonOptions(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Neko Space API", Version = "v1" });

                c.UseAllOfToExtendReferenceSchemas();
                c.UseAllOfForInheritance();
                c.UseOneOfForPolymorphism();
                c.SelectDiscriminatorNameUsing(type =>
                {
                    return type.Name switch
                    {
                        nameof(OfferBasicRequest) => "OfferType",
                        _ => null
                    };
                });
                c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                 
                //c.GeneratePolymorphicSchemas();
            });

            services.AddProblemDetails();

            services.RegisterOAuth(configurationManager);

            services.RegisterCors();

            services.AddSingleton<ConfigurationManager>(configurationManager);

            services.AddScoped<IElasticSearchRepository<ElasticSearchAnimeModel, ElasticSearchAnimeQueryParameters>, ElasticSearchAnimeRepository>();
            


            services.AddScoped<AnimeRepository, AnimeRepository>();


            services.AddScoped<AnimeService, AnimeService>();

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

            config.Default.EnumMappingStrategy(EnumMappingStrategy.ByName);

            config.NewConfig<AnimeEntity, ElasticSearchAnimeModel>()
                .Map(dest => dest.DBId, src => src.Id)
                //.Map(dest => dest.ReleaseDatePeriod, src => src.Aired)
                .Map(dest => dest.Premiere, src => src.Premier);

            config.NewConfig<TextVariantSubItemEntity, ESMediaBasicTitleModel>()
                .Map(dest => dest.IsNative, src => src.IsMain);

            config.NewConfig<PremierEntity, ESPremiereModel>();

            config.NewConfig<AssociatedServiceEntity, InterconnectionLinkModel>()
                .Map(dest => dest.Id, src => src.ServiceId)
                .Map(dest => dest.ServiceName, src => src.ServiceName);

            config.NewConfig<GetAnimeQueryParameters, ElasticSearchAnimeQueryParameters>();

            config.NewConfig<ElasticSearchAnimeModel, GetAnimeResultDTO>()
                .Map(dest => dest.Id, src => src.DBId)
                .Map(dest => dest.PrimaryTitle, src => (string?) src.Titles.FirstOrDefault(x => x.
                    IsMain == true &&
                    x.Language == Data.Contracts.Enums.Language.EN
                ).Body)
                .Map(dest => dest.SecondaryTitle, src => src.Titles.Where(x =>
                    x.IsMain == true &&
                    x.Language == Data.Contracts.Enums.Language.UK
                     )
                    .Select(s => s.Body)
                    .FirstOrDefault()
                )
/*                .Map(dest => dest.PrimarySynopsis, src => src.Synopsises.Where(x =>
                    x.IsMain == true &&
                    x.Language == Data.Contracts.Enums.Language.EN
                     )
                    .Select(s => s.Body)
                    .FirstOrDefault()
                )
                .Map(dest => dest.SecondarySynopsis, src => src.Synopsises.Where(x =>
                    x.IsMain == true &&
                    x.Language == Data.Contracts.Enums.Language.UK
                     )
                    .Select(s => s.Body)
                    .FirstOrDefault()
                )*/
                ;
            config.NewConfig<MediaEntity, GetAnimeResultDTO>()
                .Map(dest => dest.PrimaryPoster, src => src.Posters.FirstOrDefault())

                ;

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
