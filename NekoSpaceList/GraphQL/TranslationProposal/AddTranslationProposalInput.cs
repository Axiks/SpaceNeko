using NekoSpaceList.Models.General;

namespace NekoSpace.API.GraphQL.TranslationProposal
{
    public record AddTranslationProposalInput(Guid AnimeId, string Proposition, Languages Language);
}
