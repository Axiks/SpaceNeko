using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.Seeding
{
    public record AddSeedingPayload(List<Anime> anime);
}
