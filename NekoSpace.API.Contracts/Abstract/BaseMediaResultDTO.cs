using NekoSpace.API.Contracts.Models.Anime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Abstract
{
    public abstract class BaseMediaResultDTO
    {
        [Required]
        public Guid Id { get; set; }
        //public double? SearchScore { get; set; }
        public int RelevantPosition { get; set; }

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
