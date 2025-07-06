namespace Tourism.Domain.Entities;

public class PredefineData : BaseStatusEntity
{
    public string Group { get; set; } = default!;
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
}
