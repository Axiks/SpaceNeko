using Microsoft.EntityFrameworkCore;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.Seeding
{
    public record AddSeedingPayload(DbSet<Anime> anime);
}
