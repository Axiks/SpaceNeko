using NekoSpace.Data.Contracts.Enumerations;

namespace NekoSpace.API.GraphQL.UserLibraryEntry
{
    public record UserLibraryEntryInput(Guid animeId, bool? isFavorite, float? ratingValue, UserViewStatus? viewStatus);
}
