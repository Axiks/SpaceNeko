using static NekoSpaceList.Models.General.GeneralModel;

namespace NekoSpaceList.Models.Anime
{
    public class AnotherAnimeService : AnotherService
    {
        public int? KitsuId { get; set; }
        public string? NotifyId { get; set; }
        public string? AnimePlanetId { get; set; }
        public int? AniSearchId { get; set; }
        public int? LivechartMeId { get; set; }
        public int? MyAnimeList { get; set; }
    }
}
