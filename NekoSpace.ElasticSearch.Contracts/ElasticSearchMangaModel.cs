using NekoSpace.Common.Enums;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchMangaModel : ElasticSearchMediaBasicModel
    {
        public int Volumes { get; set; }
        public int ChaptersCount { get; set; }
        public MangaType Type { get; set; }
        public PublishedStatus PublishedStatus { get; set; }
        public ESReleaseDatePeriod PublishedPeriod { get; set; }

    }
}
