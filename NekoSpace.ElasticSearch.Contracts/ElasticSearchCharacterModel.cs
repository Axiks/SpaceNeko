using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchCharacterModel
    {
        public ICollection<ESMediaBasicTitleModel> Names { get; set; }
        public ICollection<ESMediaBasicTitleModel> Descriptions { get; set; }
    }
}
