using NekoSpace.Data.Contracts.Entities.Enumerations;

namespace NekoSpace.API.GraphQL.TranslationProposal
{
    public record CreateTranslationProposalInput(Guid AnimeId, string Proposition, Languages Language);
}
