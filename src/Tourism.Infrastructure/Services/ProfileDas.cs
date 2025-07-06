using Tourism.Domain.Services;
using OpenTelemetry.Trace;

namespace Tourism.Infrastructure.Services;

public class ProfileDas : IProfileDas
{
    public Task DemoAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}