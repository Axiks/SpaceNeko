using NekoSpace.Core.Startup;
using NekoSpace.Core.Startup.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterService(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

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
