namespace Tourism.Domain.Services;

public interface IProfileDas : IBaseDas
{
    Task DemoAsync(CancellationToken cancellationToken);
}
