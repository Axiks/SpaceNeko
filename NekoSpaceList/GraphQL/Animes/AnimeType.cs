using NekoSpaceList.Models.Anime;
using HotChocolate.Types;

namespace NekoSpace.API.GraphQL.Animes
{
    public class AnimeType : ObjectType<Anime>
    {
        protected override void Configure(IObjectTypeDescriptor<Anime> descriptor)
        {
            descriptor.Description("Information about Anime.");

            descriptor.
                Field(p => p.Id)
                .Description("");

            descriptor.
                Field(p => p.MalId)
                .Description("Need Delete")
                .Ignore();

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
                Field(p => p.Genres)
                .Description("List of anime genres");

            descriptor.
                Field(p => p.NumEpisodes)
                .Description("The number of series (indicate which series. Those that came out, or should there be?)");

            descriptor.
                Field(p => p.Premier)
                .Description("Premiere date");

            descriptor.
                Field(p => p.Type)
                .Description("Anime type");

            descriptor.
                Field(p => p.EpisodesDurationSeconds)
                .Description("Average episode duration");

            descriptor.
                Field(p => p.Characters)
                .Description("List of anime characters");

            descriptor.
                Field(p => p.Aired)
                .Description("Anime broadcast period");

            descriptor.
                Field(p => p.AiringStatus)
                .Description("Anime release status");

            descriptor.
                Field(p => p.AgeRating)
                .Description("Age restrictions");

            descriptor.
                Field(p => p.Source)
                .Description("Primary source");

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
