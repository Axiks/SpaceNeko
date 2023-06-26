using NekoSpace.Common.Enums;
using NekoSpace.Data.Contracts.Enums;
using NekoSpace.ElasticSearch.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.ElasticSearch
{
    public class ElasticSearchMediaBasicModel : ElasticSearchModelBasic
    {
        public List<ESMediaBasicTitleModel> Titles { get; set; }
        public ICollection<ESMediaBasicTitleModel> Synopsises { get; set; }
        public AgeRating AgeRating { get; set; }
        public Source Source { get; set; }
        public ESPremiereModel Premiere { get; set; }
    }
}
