using AnimeDB;
using Microsoft.EntityFrameworkCore;
using NekoSpace.Data.Interfaces;
using NekoSpace.Data.Repository;
using NekoSpace.Seed;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.Manga;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
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
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IMangaRepository, MangaRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

builder.Services.AddScoped<IDBSeed<Anime>, OfflineAnimeDbSeed>(provider =>
{
    return new OfflineAnimeDbSeed(){};
});

//builder.Services.AddScoped <>

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

// Отримання даних
app.MapGet("/GetAnimes", (ApplicationDbContext db) => db.Animes.ToList());

app.Run();