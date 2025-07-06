namespace Tourism.Domain.Entities;

public class AdministrativeDivision : BaseStatusEntity
{
    public string Name { get; set; } = default!;
    public Guid? ParentId { get; set; }
    public string? Description { get; set; }
}