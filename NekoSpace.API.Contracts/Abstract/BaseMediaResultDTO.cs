using NekoSpace.API.Contracts.Models.Anime;
using NekoSpace.API.Contracts.Models.AnimeService;
using NekoSpace.API.Contracts.Models.Manga;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.API.Contracts.Abstract
{
    [SwaggerSubType(typeof(GetAnimeResultDTO))]
    [SwaggerSubType(typeof(GetMangaResultDTO))]
    public abstract class BaseMediaResultDTO
    {
        [Required]
        public Guid Id { get; set; }
        //public double? SearchScore { get; set; }
        
        //public int RelevantPosition { get; set; }

        public string PrimaryTitle { get; set; }//+
        public string? SecondaryTitle { get; set; }//+
        public string? PrimarySynopsis { get; set; }//+
        public string? SecondarySynopsis { get; set; }//+
        public PremierDTO Premiere { get; set; }//+
        public Poster? PrimaryPoster { get; set; }  //FromDB
        public Poster? SecondaryPoster { get; set; }  //FromDB

        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        [Required]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
