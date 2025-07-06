namespace Tourism.Domain.Entities;

public class JobTitle : PredefineData
{
    public Guid DepartmentId { get; set; }
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Description { get; set; }
}
