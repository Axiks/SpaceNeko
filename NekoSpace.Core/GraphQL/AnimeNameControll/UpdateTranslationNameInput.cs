using NekoSpace.Data.Contracts.Enumerations;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.AnimeNameControll
{
    public record UpdateTranslationNameInput(Guid Id, string Body, Languages Language, bool IsOriginal);
}
