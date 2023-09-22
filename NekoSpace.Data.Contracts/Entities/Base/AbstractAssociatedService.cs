using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.Data.Contracts.Entities.Base
{
    public abstract class AbstractAssociatedService<T> where T : MediaEntity
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public Guid MediaId { get; set; }
        public T Media { get; set; }
    }
}
