using NekoSpace.Data.Contracts.Entities.Base;
using NekoSpace.Data.Contracts.Enums;
using NekoSpaceList.Models.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NekoSpace.Data.Contracts.Entities.General;

public abstract class ImageEntity : RootVariantSubItemEntity
{
    [Required]
    public string Original { get; set; }
    public string? Large { get; set; }
    public string? Medium { get; set; }
    public string? Small { get; set; }
    [Required]
    public ItemFrom From { get; set; }
}
