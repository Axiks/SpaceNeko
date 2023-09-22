using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.Manga;
using System.ComponentModel.DataAnnotations;

namespace NekoSpaceList.Models.General
{
    public partial class GeneralModel
    {
        public class GenreEntity
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public ICollection<AnimeGenreEntity> Animes { get; set; }
            public ICollection<MangaGenreEntity> Mangas { get; set; }
        }
    }
}
