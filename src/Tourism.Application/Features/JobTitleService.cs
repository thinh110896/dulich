using Tourism.Application.Interfaces;
using Tourism.Application.Models.Dto;
using Tourism.Domain.Entities;
using Tourism.Domain.Helpers;
using Tourism.Domain.Services;
using Tourism.Domain.Shared;
using Tourism.Shared.Models;

namespace Tourism.Application.Features;

public class JobTitleService(IJobTitleDas jobTitleDas, IDepartmentDas departmentDas) : IJobTitleService
{
    public async Task<BaseProcess<List<JobTitleModel>>> GetAllJobTitles(PagedRequest request, CancellationToken cancellationToken)
{
    var data = await jobTitleDas.GetAllAsync(request, cancellationToken);

    var jobTitleModels = data.Items.Select(d => new JobTitleModel
    {
        Id = d.Id,
        Key = d.Key,
        Value = d.Value,
        DepartmentId = d.DepartmentId,
        EffectiveDate = d.EffectiveDate,
        ExpirationDate = d.ExpirationDate
    }).ToList();

    return new BaseProcess<List<JobTitleModel>>(jobTitleModels, []);
}


    public async Task<BaseProcess<JobTitleModel>> GetJobTitleById(Guid id, CancellationToken cancellationToken)
    {
        var jobTitle = await jobTitleDas.GetByIdAsync(id, cancellationToken);
        var errors = new List<Error>();
        if (jobTitle == null)
        {
            errors.Add(ReturnCode.JOB_TITLE_NOT_FOUND.ToErrorCode());
            return new BaseProcess<JobTitleModel>(null, errors);
        }
        return new BaseProcess<JobTitleModel>(MapperHelper.MapToModel<JobTitleModel>(jobTitle), errors);
    }

    public async Task<BaseProcess<Guid>> AddJobTitle(JobTitleRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var department = await departmentDas.GetByIdAsync(request.DepartmentId, cancellationToken);
        if (department == null)
            errors.Add(ReturnCode.DEPARTMENT_NOT_FOUND.ToErrorCode());
        if (request.EffectiveDate > request.ExpirationDate)
            errors.Add(ReturnCode.EFFECTIVE_DONT_GREATER_THAN_EXPIRATION_DATE.ToErrorCode());
        if (errors.Count == 0)
        {
            var jobTitle = MapperHelper.CreateEntity<JobTitle>(request);
            jobTitle.Group = PredefineGroups.JobTitle;
            jobTitle.Status = StatusConst.Active;
            jobTitle.CreatedAt = DateTimeOffset.UtcNow;
            await jobTitleDas.AddAsync(jobTitle, cancellationToken);
            return new BaseProcess<Guid>(jobTitle.Id, errors);
        }
        return new BaseProcess<Guid>(Guid.Empty, errors);
    }

    public async Task<BaseProcess<JobTitleModel>> UpdateJobTitle(Guid id, JobTitleModel request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        if (id != request.Id)
            errors.Add(ReturnCode.REQUEST_INVALID.ToErrorCode());
        var department = await departmentDas.GetByIdAsync(request.DepartmentId, cancellationToken);
        if (department == null)
            errors.Add(ReturnCode.DEPARTMENT_NOT_FOUND.ToErrorCode());
        var jobTitle = await jobTitleDas.GetByIdAsync(id, cancellationToken);
        if (jobTitle == null)
            errors.Add(ReturnCode.JOB_TITLE_NOT_FOUND.ToErrorCode());
        if (errors.Count == 0)
        {
            MapperHelper.UpdateEntity(jobTitle, request);
            jobTitle.UpdatedAt = DateTimeOffset.UtcNow;
            await jobTitleDas.UpdateAsync(id, jobTitle, cancellationToken);
        }
        return new BaseProcess<JobTitleModel>(request, errors);
    }

    public async Task<BaseProcess<Guid>> DeleteJobTitle(Guid id, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var jobTitle = await jobTitleDas.GetByIdAsync(id, cancellationToken);
        if (jobTitle == null)
            errors.Add(ReturnCode.JOB_TITLE_NOT_FOUND.ToErrorCode());
        if (errors.Count == 0)
        {
            await jobTitleDas.DeleteAsync(id, cancellationToken);
        }
        return new BaseProcess<Guid>(id, errors);
    }
}
