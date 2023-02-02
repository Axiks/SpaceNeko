using NekoSpaceList.Models.Manga;

namespace NekoSpace.API.GraphQL.Mangas
{
    public class MangaType : ObjectType<Manga>
    {
        protected override void Configure(IObjectTypeDescriptor<Manga> descriptor)
        {
            descriptor.Description("Information about Manga.");

            descriptor.
                Field(p => p.Id)
                .Description("Manga Id");

            descriptor.
                Field(p => p.Titles)
                .Description("Variants of anime titles in different languages");

            descriptor.
                Field(p => p.Synopsises)
                .Description("Variants of anime synopsises in different languages");

            descriptor.
                Field(p => p.Posters)
                .Description("Various options for posters");

            descriptor.
                 Field(p => p.Covers)
                 .Description("Various options for covers");

            descriptor.
                 Field(p => p.ChaptersCount)
                 .Description("Chapters Manga Count");

            descriptor.
                Field(p => p.Genres)
                .Description("List of anime genres");

            descriptor.
                Field(p => p.Characters)
                .Description("List of manga characters");

            descriptor.
                Field(p => p.Published)
                .Description("Published date");

            descriptor.
                Field(p => p.Publishing)
                .Description("Is Publishing");

            descriptor.
                Field(p => p.ReadStatus)
                .Description("User reading status (Where user is login!!!)");

            descriptor.
                Field(p => p.Type)
                .Description("Manga type");

            descriptor.
                Field(p => p.Volumes)
                .Description("The number of volumes");

            descriptor.
                Field(p => p.AnotherService)
                .Description("List of services with information about the title");

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
