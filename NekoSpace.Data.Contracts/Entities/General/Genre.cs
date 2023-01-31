using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.Manga;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public partial class GeneralModel
    {
        public class Genre
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public ICollection<AnimeGenre> Animes { get; set; }
            public ICollection<MangaGenre> Mangas { get; set; }
        }
    }
}
