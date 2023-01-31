using NekoSpace.Data.Contracts.Entities.Enumerations;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.AnimeNameControll
{
    public record UpdateTranslationNameInput(Guid Id, string Body, Languages Language, bool IsOriginal);
}
