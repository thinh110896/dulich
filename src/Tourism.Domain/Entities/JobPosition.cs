namespace Tourism.Domain.Entities;

public class JobPosition : PredefineData
{
    public Guid DepartmentId { get; set; }
    public Guid TitleId { get; set; }
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Description { get; set; }
}
