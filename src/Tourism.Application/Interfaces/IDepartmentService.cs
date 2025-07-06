using Tourism.Application.Models.Dto;
using Tourism.Domain.Services;
using Tourism.Shared.Models;

namespace Tourism.Application.Interfaces;

public interface IDepartmentService : IBaseService
{
    Task<BaseProcess<List<DepartmentModel>>> GetAllDepartmentAsync(PagedRequest request, CancellationToken cancellationToken);
    Task< BaseProcess<DepartmentModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> CreateDepartmentAsync(DepartmentRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<DepartmentModel>> UpdateDepartmentAsync(Guid id, DepartmentModel request, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> DeleteDepartmentAsync(Guid id, CancellationToken cancellationToken);
}