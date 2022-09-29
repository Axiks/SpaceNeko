using NekoSpace.API.GraphQL.TranslationDecision;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.General;

namespace NekoSpace.API.GraphQL.AnimeNameControll
{
    public record UpdateTranslationNameInput(Guid Id, string Body, Languages Language, bool IsOriginal);
}
