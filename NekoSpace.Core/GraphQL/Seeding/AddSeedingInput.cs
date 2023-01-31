using NekoSpaceList.Models.General;

namespace NekoSpace.API.GraphQL.Seeding
{
    public record AddSeedingInput(int? offset, int? page, bool? InRecreateDB);
}
