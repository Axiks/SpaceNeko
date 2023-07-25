using NekoSpace.Data.Contracts.Entities.General;
using System.ComponentModel.DataAnnotations;

namespace NekoSpace.Data.Contracts.Entities.Base;

public class MediaEntity
{
    public Guid Id { get; set; }
    public ICollection<MediaPosterEntity> Posters { get; set; }
    public ICollection<MediaCoverEntity> Covers { get; set; }
    public List<AssociatedServiceEntity> AssociatedService { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    [Required]
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
}
