using Tourism.Domain.Entities;
using Tourism.Shared.Models;

namespace Tourism.Domain.Services;

public interface IJobPositionDas : IBaseDas
{
    Task<JobPosition> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(JobPosition JobPosition, CancellationToken cancellationToken);
    Task<JobPosition> UpdateAsync(Guid id ,JobPosition jobPosition, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedResult<JobPosition>> GetAllAsync(PagedRequest pagedRequest,CancellationToken cancellationToken);
}
