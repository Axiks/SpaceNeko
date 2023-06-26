using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Data.Contracts.Entities.General
{
    public class AssociatedServiceEntity
    {
        public Guid Id { get; set; }
        public Guid MediaEntityId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}
