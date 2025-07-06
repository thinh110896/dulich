using Tourism.Application.Models.Dto;
using Tourism.Domain.Services;
using Tourism.Shared.Models;

namespace Tourism.Application.Interfaces;

public interface IJobPositionService : IBaseService
{
    Task<BaseProcess<List<JobPositionModel>>> GetAllJobPositionAsync(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<JobPositionModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> CreateJobPositionAsync(JobPositionRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<JobPositionModel>> UpdateJobPositionAsync(Guid id, JobPositionModel request, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> DeleteJobPositionAsync(Guid id, CancellationToken cancellationToken);
}