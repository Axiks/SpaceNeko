using NekoSpaceList.Models.General;

namespace NekoSpace.API.GraphQL.TranslationProposal
{
    public record CreateTranslationProposalInput(Guid AnimeId, string Proposition, Languages Language);
}
