using NekoSpace.API.GraphQL.TranslationProposal;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.TranslationDecision
{
    public record AddTranslationDecisionPayload(AnimeTitle animeTitle);
}
