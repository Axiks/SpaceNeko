using NekoSpace.API.GraphQL.TranslationProposal;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.TranslationProposalDecision
{
    public record SetDecisionTranslationProposalPayload(AnimeTitle animeTitle);
}
