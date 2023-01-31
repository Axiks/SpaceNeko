namespace NekoSpaceList.Models.General
{
    public partial class GeneralModel
    {
        public abstract class AnotherService
        {
            public Guid Id { get; set; }
            public int? AnimeDBId { get; set; }
            public int? AnilistId { get; set; }
        }
    }
}
