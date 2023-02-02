using NekoSpaceList.Models.General;

namespace NekoSpace.API.GraphQL.AnimeTitleItem
{
    public record AnimeTypeItemInput(Guid TitleId,  bool? IsOriginal, string? Body, bool? IsHiden);
}
