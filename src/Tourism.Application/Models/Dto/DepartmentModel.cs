using Tourism.Shared.Models.Predefine;

namespace Tourism.Application.Models.Dto;

public class DepartmentModel : DepartmentRequest
{
    public Guid Id { get; set; }
}
public class DepartmentRequest : PredefineDataModel
{
    public string? Description { get; set; }
    public string Status { get; set; }= default!;
    public string FullName { get; set; } = default!;
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
}