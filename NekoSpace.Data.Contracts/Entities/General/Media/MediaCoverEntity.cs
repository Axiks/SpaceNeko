﻿using NekoSpace.Data.Contracts.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Data.Contracts.Entities.General.Media
{
    public class MediaCoverEntity : ImageEntity
    {
        public Guid MediaId { get; set; }
        public MediaEntity Media { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
