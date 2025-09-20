using Domain.Helpers;

namespace Domain.Models;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        Created = DateTime.UtcNow;
        Updated = DateTime.UtcNow;
    }

    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}