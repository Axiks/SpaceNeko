using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.AnimeTitleItem
{
    public record AnimeTypeItemPayload(AnimeTitle? animeTitle, string? error);
}
