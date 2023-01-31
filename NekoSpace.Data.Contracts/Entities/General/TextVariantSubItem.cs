using NekoSpace.Data.Contracts.Entities.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NekoSpaceList.Models.General
{
    public partial class GeneralModel
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

        public abstract class TextVariantSubItem<T> where T : Media
        {
            public Guid Id { get; set; }
            [Required]
            public string Body { get; set; }
            public bool LanguageDetectionBySystem { get; set; } = false;
            [Required]
            public Languages Language { get; set; }
            [Required]
            public ItemFrom From { get; set; }
            [Required]
            public bool IsMain { get; set; }
            public bool IsOriginal { get; set; }
            [NotMapped]
            private protected Guid MediaId { get; set; }
            [NotMapped]
            private protected T Media { get; set; }
            public bool? IsAcceptProposal { get; set; }
            [Required]
            public bool IsHidden { get; set; } = false;
            public Guid? CreatorUserId { get; set; }
            [Required]
            public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
            [Required]
            public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        }
    }
}
