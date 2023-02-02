using HotChocolate.Types;
using NekoSpaceList.Models.CharacterModels;

namespace NekoSpace.API.GraphQL.Characters
{
    public class CharacterType : ObjectType<Character>
    {
        protected override void Configure(IObjectTypeDescriptor<Character> descriptor)
        {
            descriptor.Description("Information about Character.");

            descriptor.
                Field(p => p.Id)
                .Description("Character Id");

            descriptor.
                Field(p => p.Names)
                .Description("Variants of manga character name in different languages");

            descriptor.
                Field(p => p.Abouts)
                .Description("Variants of manga character about in different languages");

            descriptor.
                Field(p => p.Posters)
                .Description("Various options for posters");

            descriptor.
                Field(p => p.Covers)
                .Description("Various options for covers");

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
