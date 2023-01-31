﻿using NekoSpaceList.Models.Anime;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Models.User
{
    public class UserRatingAnime
    {
        [Required]
        public float RatingValue { get; set; }
        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public string UserId { get; set; }
        public NekoUser User { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}