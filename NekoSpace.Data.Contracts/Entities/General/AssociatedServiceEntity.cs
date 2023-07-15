using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpaceList.Models.Anime;
using NekoSpaceList.Models.CharacterModels;
using NekoSpaceList.Models.Manga;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Data.Contracts.Entities.General
{
    public class AssociatedServiceEntity
    {
        public Guid Id { get; set; }
        public Guid MediaId { get; set; }
        public MediaEntity Media { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
