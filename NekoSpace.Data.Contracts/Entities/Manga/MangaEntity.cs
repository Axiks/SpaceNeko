using NekoSpace.Common.Enums;
using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Entities.Manga;
using NekoSpace.Data.Contracts.Enums;
using NekoSpaceList.Models.Anime;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.Manga
{
    public class MangaEntity : MediaEntity
    {
        public ICollection<MangaTitleEntity> Titles { get; set; }
        public ICollection<MangaSynopsisEntity> Synopsises { get; set; }
        [Required]
        public int ChaptersCount { get; set; }
        public ICollection<MangaGenreEntity> Genres { get; set; }
        public ICollection<MangaCharacterEntity> Characters { get; set; }
        [Required]
        public PublishedEntity Published { get; set; }
        public bool Publishing { get; set; }
        public MangaStatus ReadStatus { get; set; } // Where user Login
        public MangaType Type { get; set; }
        [Required]
        public int Volumes { get; set; }
    }
}
