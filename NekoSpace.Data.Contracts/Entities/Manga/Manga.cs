using NekoSpace.Data.Contracts.Entities.Enumerations;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.Manga
{
    public class Manga : Media
    {
        public ICollection<MangaTitle> Titles { get; set; }
        public ICollection<MangaSynopsis> Synopsises { get; set; }
        public ICollection<MangaPoster> Posters { get; set; }
        public ICollection<MangaCover> Covers { get; set; }
        [Required]
        public int ChaptersCount { get; set; }
        public ICollection<MangaGenre> Genres { get; set; }
        public ICollection<MangaCharacter> Characters { get; set; }
        [Required]
        public Published Published { get; set; }
        public bool Publishing { get; set; }
        public MangaStatus ReadStatus { get; set; } // Where user Login
        public MangaType Type { get; set; }
        [Required]
        public int Volumes { get; set; }
        public AnotherMangaService AnotherService { get; set; }
    }
}
