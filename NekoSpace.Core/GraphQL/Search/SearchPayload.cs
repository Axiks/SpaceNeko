using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.Search
{
    public record SearchPayload(List<SearchAnimeItem> searchAnimeItems);
}

public record SearchAnimeItem(Anime anime, AnimeTitle currentAnimeTitle);