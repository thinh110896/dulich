namespace Tourism.Domain.Entities;

public abstract class BaseStatusEntity : BaseEntity
{
    public string Status { get; set; } = default!;
}
