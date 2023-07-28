using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.ElasticSearch
{
    public class ESPremiereModel
    {
        public int? Year { get; set; }
        public Season Season { get; set; }
    }
}