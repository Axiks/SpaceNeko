using AnimeDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NekoSpace.API;
using NekoSpace.API.Configuration;
using NekoSpace.API.GraphQL;
using NekoSpace.API.GraphQL.Animes;
using NekoSpace.Data.Interfaces;
using NekoSpace.Data.Models.User;
using NekoSpace.Data.Repository;
using NekoSpace.Seed;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using System.Text;

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

builder.Services.AddScoped<IDBSeed<Anime>, OfflineAnimeDbSeed>(provider =>
{
    return new OfflineAnimeDbSeed() { };
});

// register graphQL
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>()
    .RegisterService<IDBSeed<Anime>>()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<AnimeType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IMangaRepository, MangaRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();*/

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager("ui/voyager");
});

// Seeding user and roles
/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData seeder = new SeedData();
    await seeder.InitializeAsync(services);
}*/

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}*/
app.MigrateDatabase();

app.Run();