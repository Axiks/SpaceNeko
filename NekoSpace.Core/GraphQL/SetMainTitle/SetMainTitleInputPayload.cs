using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.SetMainTitle
{
    public record SetMainTitleInputPayload(AnimeTitle? animeTitle, String? error);
}
