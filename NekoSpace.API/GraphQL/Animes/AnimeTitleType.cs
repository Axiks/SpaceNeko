using NekoSpaceList.Models.Anime;
using HotChocolate.Types;

namespace NekoSpace.API.GraphQL.Animes
{
    public class AnimeTitleType : ObjectType<AnimeTitle>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimeTitle> descriptor)
        {
            descriptor.Description("Information about Anime titles.");

            descriptor.
                Field(p => p.Id)
                .Description("Title Id");

            descriptor.
                Field(p => p.Anime)
                .Description("Belongs to this anime");

            descriptor.
                Field(p => p.IsMain)
                .Description("The main option");

            descriptor.
                Field(p => p.Body)
                .Description("Option name");

            descriptor.
                Field(p => p.CreatedAt)
                .Description("The date of the offer");

            descriptor.
                Field(p => p.CreatorUserId)
                .Description("Offer provided by this user");

            descriptor.
                Field(p => p.IsAcceptProposal)
                .Description("Is the offer accepted?");

            descriptor.
                Field(p => p.IsHidden)
                .Description("Hiding the field");

            descriptor.
                Field(p => p.IsOriginal)
                .Description("Is this the official name");

            descriptor.
                Field(p => p.Language)
                .Description("Translation language");

            descriptor.
                Field(p => p.AnimeId)
                .Description("Id media belongs");

            descriptor.
                Field(p => p.UpdatedAt)
                .Description("Time of last update");

        }
    }
}
