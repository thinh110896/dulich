namespace Tourism.Shared.Models.Predefine;

public class PredefineDataModel
{
    public string Value { get; set; } = default!;
    public string Key { get; set; } = default!;
    public string Group { get; set; } = default!;
}
public class PredefineDataRequest : PredefineDataModel
{
    public Guid Id { get; set; } = default!;
}
