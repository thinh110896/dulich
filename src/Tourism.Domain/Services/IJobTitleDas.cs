using Tourism.Domain.Entities;
using Tourism.Shared.Models;

namespace Tourism.Domain.Services;

public interface IJobTitleDas : IBaseDas
{
    Task<JobTitle?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(JobTitle jobTitle, CancellationToken cancellationToken);
    Task<JobTitle> UpdateAsync(Guid id, JobTitle jobTitle, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedResult<JobTitle>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken);
}
