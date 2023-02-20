using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.AnimeService
{
    public class UpdateAnimeTitleInput
    {
        [Required]
        public Guid TitleId { get; set; }
        public bool IsMain { get; set; }
        public bool IsHidden { get; set; }
        public bool IsAcceptProposal { get; set; }

    }
}
