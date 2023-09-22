using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Models
{
    public class Media2MediaLink
    {
        public MediaTypeEnum MediaType { get; }
        public RelationTypeEnum RelationType { get; }
        //public long MyAnimeListId { get; set; }
        public ResourceEnum Resource { get; }
        public string Id { get; }

        public Media2MediaLink(MediaTypeEnum mediaType, RelationTypeEnum relationType, ResourceEnum resource, string id)
        {
            MediaType = mediaType;
            RelationType = relationType;
            Resource = resource;
            Id = id;
        }
    }
}
