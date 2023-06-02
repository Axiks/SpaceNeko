using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
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

app.Run();
