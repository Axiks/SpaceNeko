using AnimeDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.API.Configuration;
using NekoSpace.API.GraphQL;
using NekoSpace.API.GraphQL.Animes;
using NekoSpace.API.GraphQL.Users;
using NekoSpace.API.Helpers;
using NekoSpace.Data.Models.User;
using NekoSpaceList.Models.Anime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(
        options => options.
            UseNpgsql("Server=postgres_db;Database=anilist_db;Username=neko;Password=mya", b => b.MigrationsAssembly("NekoSpace.API"))
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .LogTo(
                Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information
            )
        );

builder.Services.AddIdentity<NekoUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<ApplicationDbContext>(p => p.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

/*builder.Services.AddScoped<IRepositoryDriver<Anime, int>, OfflineAnimeDbSeed>(provider =>
{
    return new OfflineAnimeDbSeed() { };
});*/

/*builder.Services.AddScoped<IDBSeed<Anime>, MalDriver>(provider =>
{
    return new MalDriver() { };
});*/

//builder.Services.AddScoped<IUpdateDB, UpdateDB>();

// register graphQL
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>()
    //.RegisterService<IRepositoryDriver<Anime, int>>()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<AnimeType>()
    .AddType<UserType>()
    .AddType<AnimeTitleType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
JwtConfig jwtConfig = new JwtConfig(builder.Configuration["JwtConfig:Secret"])
{
    validIssuer = builder.Configuration["JwtConfig:ValidIssuer"],
    validAudience = builder.Configuration["JwtConfig:ValidAudience"]
};

builder.Services.AddSingleton<JwtConfig>(jwtConfig);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtConfig.GetSymmetricSecurityKey(),
                ValidateIssuer = false,
                ValidIssuer = jwtConfig.validIssuer,
                ValidateAudience = false,
                ValidAudience = jwtConfig.validAudience,
                ValidateLifetime = true,
                RequireExpirationTime = false, // Only test!
            };
    });

builder.Services.AddAuthorization();

/*builder.Services.AddCors( option =>
{
    option.AddPolicy("allowedOrigin",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
});*/

builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "allowedOrigin",
            policy =>
            {
                policy.WithOrigins("http://localhost:3000",
                    "https://localhost:3000",
                    "http://localhost:2083",
                    "https://localhost:2083",
                    "https://web.neko3.space"
                    )
                .AllowAnyHeader()
                .AllowAnyMethod();
            }
        );
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("allowedOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager("ui/voyager");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

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

app.Run();
