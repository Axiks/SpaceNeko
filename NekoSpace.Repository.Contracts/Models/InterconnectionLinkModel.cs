using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Repository.Contracts.Models
{
    public class InterconnectionLinkModel
    {
        public required string ServiceName { get; set; }
        public required string Id { get; set; }
    }
}
