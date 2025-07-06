using Tourism.Shared.Models.Predefine;

namespace Tourism.Application.Models.Dto;

public class JobTitleModel : JobTitleRequest
{
        public Guid Id { get; set; }
}
public class JobTitleRequest  : PredefineDataModel
{
        public Guid DepartmentId { get; set; } = default!;
        public DateTimeOffset EffectiveDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
}