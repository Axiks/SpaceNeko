using NekoSpace.Data.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Abstract
{
    public abstract class VariantSubItem : BaseItem
    {
        public string Body { get; set; }
        public Language Language { get; set; }
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
    }
}
