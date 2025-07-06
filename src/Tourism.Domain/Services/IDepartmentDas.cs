using Tourism.Domain.Entities;
using Tourism.Shared.Models;

namespace Tourism.Domain.Services;

public interface IDepartmentDas : IBaseDas
{
    Task<PagedResult<Department>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken);
    Task<Department> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Department Department, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, Department Department, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<string> GenerateDepartmentCodeAsync(string prefix);

}
