using HotChocolate.Types;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.AnimeTitleItem
{
    public class AnimeTitleType : ObjectType<AnimeTitle>
    {
        protected override void Configure(IObjectTypeDescriptor<AnimeTitle> descriptor)
        {
            descriptor.Description("Information about Media title.");

            descriptor.
                Field(p => p.Id)
                .Description("Title Id");

            descriptor.
                Field(p => p.CreatorUserId)
                .Description("User ID If the Creation");

            descriptor.
                Field(p => p.UpdatedAt)
                .Ignore()
                .Description("Date updated to the database");

            descriptor.
                Field(p => p.CreatedAt)
                .Ignore()
                .Description("Date added to the database");

        }
    }
}
