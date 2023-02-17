using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.UserService.UserUpdates
{
    public class UserUpdateItem
    {
        public BasicAnimeResponse BasicAnimeResponse { get; set; } //Це равлізувати
        public int Score { get; set; }
        public int EpisodesSeen { get; set; }
        public int EpisodesTotal { get; set; }
        public bool IsFavorite { get; set; }
        public AiringStatus AiringStatus { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
