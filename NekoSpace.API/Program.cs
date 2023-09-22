using NekoSpace.API.Startup;
using NekoSpace.API.Startup.Setup;

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


app.Run();
