namespace NekoSpace.API.Startup.Setup;

using Microsoft.Extensions.DependencyInjection;
using NekoSpace.Data;

public static class GraphQlSetup
{
    public static IServiceCollection RegisterGraphQl(this IServiceCollection services)
    {
        /*        services
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
                        .AddProjections();*/

        return services;
    }
}
