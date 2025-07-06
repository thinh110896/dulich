namespace Tourism.Domain.Entities;

public class ContractAppendices : PredefineData
{
    public Guid TitleId { get; set; }
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Description { get; set; }
}
