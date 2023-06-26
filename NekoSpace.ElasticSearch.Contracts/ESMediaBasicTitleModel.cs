using NekoSpace.Data.Contracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.ElasticSearch
{
    public class ESMediaBasicTitleModel
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Language Language { get; set; }
        public ItemFrom From { get; set; }
        public bool IsMain { get; set; }
        public bool IsNative{ get; set; }
        public bool IsHidden { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}