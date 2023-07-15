using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Hosting;
using NekoSpace.API.Helpers;
using NekoSpace.API.Startup;
using NekoSpace.API.Startup.Setup;
using NekoSpace.Core.Services.DatabaseService;
using NekoSpace.Data;
using NekoSpaceList.Models.Anime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterService(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

// Api errors print
app.UseStatusCodePages();
app.UseExceptionHandler();

app.UseRouting();
app.UseCors("allowedOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapGraphQL();
    //endpoints.MapGraphQLVoyager("ui/voyager");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.ConfigureSeed();

/*var serviceScopeFactory = app.Services.GetService<IServiceScopeFactory>();
using (var scope = serviceScopeFactory.CreateScope())
{
    var services = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>;
    builder.Services.AddScoped<ISeedingService, SeedingService>();
}*/



var serviceScopeFactory2 = app.Services.GetService<IServiceScopeFactory>();
using (var scope = serviceScopeFactory2.CreateScope())
{
    var services = scope.ServiceProvider;
    var myClass = services.GetRequiredService<ApplicationDbContext>();

    myClass.ChangeTracker.Tracked += Test.UpdateTimestamps;

    //ChangeTracker.Tracked += UpdateTimestamps;
}

app.Run();

public static class Test{
    public static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is AnimeEntity entityWithTimestamps)
        {
            switch (e.Entry.State)
            {
                case EntityState.Deleted:
                    //entityWithTimestamps.Deleted = DateTime.UtcNow;
                    Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                    break;
                case EntityState.Modified:
                    //entityWithTimestamps.Modified = DateTime.UtcNow;
                    Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                    break;
                case EntityState.Added:
                    //entityWithTimestamps.Added = DateTime.UtcNow;
                    Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                    var animeObject = e.Entry.Entity;
                    break;
            }
        }
    }
}

