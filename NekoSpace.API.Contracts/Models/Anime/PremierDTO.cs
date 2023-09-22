using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.Anime
{
    public class PremierDTO
    {
        public int? Year { get; set; }
        public Season? Season { get; set; }
    }
}
