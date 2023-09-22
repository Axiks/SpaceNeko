using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Seed.Models;

namespace NekoSpace.Seed.Interfaces
{
    public class RTO<T> where T : MediaEntity
    {
        public List<Media2MediaLink> Media2MediaLinks { get; set; }
        public T contain { get; }
        public RTO( T contain)
        {
            this.contain = contain;
        }
    }
}
