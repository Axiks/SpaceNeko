using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.API.GraphQL;
using NekoSpace.API.GraphQL.Animes;
using NekoSpace.Data.Interfaces;
using NekoSpace.Data.Repository;
using NekoSpace.Seed;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(
        options => options.
            UseNpgsql("Host=localhost;Database=anilist_db;Username=neko;Password=mya", b => b.MigrationsAssembly("NekoSpace.API"))
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .LogTo(
                Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information
            )
        );

builder.Services.AddScoped<IDBSeed<Anime>, OfflineAnimeDbSeed>(provider =>
{
    return new OfflineAnimeDbSeed() { };
});

// register graphQL
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>()
    .RegisterService<IDBSeed<Anime>>()
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager("ui/voyager");
});

//app.MapGraphQL();

// Отримання даних
// app.MapGet("/GetAnimes", (ApplicationDbContext db) => db.Animes.ToList());

/*app.MapGet("/RunSeeding", (ApplicationDbContext db, IDBSeed<Anime> dBSeed) => {
    //var animeRepo = db.Set<Anime>();
    var animes = dBSeed.RunSeed().ToList();

    *//*foreach (var anime in animes)
    {
        animeRepo.Add(anime);
    }
    db.SaveChanges();*//*
});*/

app.Run();