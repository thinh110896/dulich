namespace Tourism.Domain.Entities;

public class ContractTypes : PredefineData
{
    public string LegalName { get; set; } = default!;
    public Guid TitleId { get; set; }
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Description { get; set; }
}
