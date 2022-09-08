using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.Manga;

namespace NekoSpaceList.Models.General
{
    public class GeneralModel
    {
        /*        public class Name
                {
                    public int Id { get; set; }
                    public string Body { get; set; }
                    public Languages Language { get; set; }
                    public ItemFrom From { get; set; }
                    public int AnimeId { get; set; }
                    public Anime Anime { get; set; }
                    public bool IsMain { get; set; }
                    public DateTimeOffset CreatedAt { get; set; }
                    public DateTimeOffset UpdatedAt { get; set; }
                }

                public class Description
                {
                    public int Id { get; set; }
                    public string Body { get; set; }
                    public Languages Language { get; set; }
                    public ItemFrom From { get; set; }
                    public int AnimeId { get; set; }
                    public Anime Anime { get; set; }
                    public bool IsMain { get; set; }
                    public DateTimeOffset CreatedAt { get; set; }
                    public DateTimeOffset UpdatedAt { get; set; }
                }*/

        public interface ITextVariantSubItem<T> where T : IMedia
        {
            public Guid Id { get; set; }
            public string Body { get; set; }
            public Languages Language { get; set; }
            public ItemFrom From { get; set; }
            public bool IsMain { get; set; }
            public bool IsOriginal { get; set; }
            Guid MediaId { get; set; }
            T Media { get; set; }
            public bool? IsAcceptProposal { get; set; }
            public Guid? CreatorUserId { get; set; }
            public DateTimeOffset CreatedAt { get; set; }
            public DateTimeOffset UpdatedAt { get; set; }
        }

        public class Genre
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<AnimeGenre> Animes { get; set; }
            public ICollection<MangaGenre> Mangas { get; set; }
        }

        public interface ITimePeriod
        {
            public Guid Id { get; set; }
            public DateTime From { get; set; }
            public DateTime? To { get; set; }
        }

        public class Image
        {
            public int Id { get; set; }
            //public Anime Anime { get; set; }
            public string Original { get; set; }
            public string? Large { get; set; }
            public string? Medium { get; set; }
            public string? Small { get; set; }
            public ItemFrom From { get; set; }
            public AnimePoster Posters { get; set; }
        }

        public abstract class AnotherService
        {
            public Guid Id { get; set; }
            public int? AnimeDBId { get; set; }
            public int? AnilistId { get; set; }
        }
    }
}
