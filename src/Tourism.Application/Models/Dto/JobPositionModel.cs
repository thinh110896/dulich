using Tourism.Shared.Models.Predefine;

namespace Tourism.Application.Models.Dto;

public class JobPositionModel : JobPositionRequest
{
        public Guid Id { get; set; }
}
public class JobPositionRequest  : PredefineDataModel
{
        public Guid DepartmentId { get; set; } = default!;
        public Guid TitleId { get; set; } = default!;
        public DateTimeOffset EffectiveDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
}