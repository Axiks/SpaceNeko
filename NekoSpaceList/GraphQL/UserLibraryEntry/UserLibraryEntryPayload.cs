using NekoSpace.Data.Models.User;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.UserLibraryEntry
{
    public record UserLibraryEntryPayload(NekoUser? user, String? error);
}
