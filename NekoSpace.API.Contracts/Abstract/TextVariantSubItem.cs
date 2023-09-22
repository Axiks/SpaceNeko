using NekoSpace.Data.Contracts.Enums;

namespace NekoSpace.API.Contracts.Abstract
{
    public abstract class TextVariantSubItem : BaseMediaResultDTO
    {
        public string Body { get; set; }
        public Language Language { get; set; }
        public bool IsMain { get; set; }
        public bool IsOriginal { get; set; }
    }
}
