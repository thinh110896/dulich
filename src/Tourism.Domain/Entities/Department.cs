namespace Tourism.Domain.Entities;

public class Department : PredefineData
{
    public string FullName { get; set; } =  default!;
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Description { get; set; }
}
