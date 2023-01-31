using NekoSpace.Seed.Models;
using NekoSpaceList.Models.General;

namespace NekoSpace.Seed.Interfaces
{
    public class RTO<T> where T : Media
    {
        public List<Media2MediaLink> Media2MediaLinks { get; set; }
        public T contain { get; }
        public RTO( T contain)
        {
            this.contain = contain;
        }
    }
}
