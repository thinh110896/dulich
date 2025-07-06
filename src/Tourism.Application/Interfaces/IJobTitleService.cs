using Tourism.Application.Models.Dto;
using Tourism.Domain.Services;
using Tourism.Shared.Models;

namespace Tourism.Application.Interfaces;

public interface IJobTitleService : IBaseService
{
    Task<BaseProcess<List<JobTitleModel>>> GetAllJobTitles(PagedRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<JobTitleModel>> GetJobTitleById(Guid id, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> AddJobTitle(JobTitleRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<JobTitleModel>> UpdateJobTitle(Guid id, JobTitleModel request, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> DeleteJobTitle(Guid id, CancellationToken cancellationToken);
}