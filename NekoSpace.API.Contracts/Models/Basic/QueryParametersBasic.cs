using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NekoSpace.API.Contracts.Models.Basic
{
    public class QueryParametersBasic
    {
        public string? q { get; set; }
        public int limit { get; set; } = 40;
        public int offset { get; set; } = 0;

    }
}
