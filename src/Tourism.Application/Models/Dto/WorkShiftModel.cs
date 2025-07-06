using Tourism.Domain.Entities;

namespace Tourism.Application.Models.Dto;

public class WorkShiftModel : WorkShiftRequest
{
        public Guid Id { get; set; }
}
public class WorkShiftRequest
{
        public string ShiftCode { get; set; } = default!;
        public string ShiftName { get; set; } = default!;
        public DateTimeOffset StartCheckIn { get; set; }
        public DateTimeOffset EndCheckOut { get; set; }
        public bool MaternityMode { get; set; }
        public int? BreakTime { get; set; }
        public int BeforeStartCheckIn { get; set; }
        public int AfterEndCheckOut { get; set; }
        public bool IsNightShift { get; set; }
        public Guid? NightShiftType { get; set; }
        public DateTimeOffset? NightShiftTime { get; set; }
}