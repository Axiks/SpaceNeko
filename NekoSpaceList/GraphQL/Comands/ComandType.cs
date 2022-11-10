using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.GraphQL.Comands
{
    public class ComandType : ObjectType<Anime>
    {
        protected override void Configure(IObjectTypeDescriptor<Anime> descriptor)
        {
            descriptor.Description("Respresent any executable commands");
        }
    }
}
