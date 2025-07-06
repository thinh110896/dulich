using Tourism.Application.Interfaces;
using Tourism.Application.Models.Dto;
using Tourism.Domain.Entities;
using Tourism.Domain.Helpers;
using Tourism.Domain.Services;
using Tourism.Domain.Shared;
using Tourism.Shared.Models;

namespace Tourism.Application.Features;

public class JobPositionService(IJobPositionDas jobPositionDas, IDepartmentDas departmentDas, IJobTitleDas jobTitleDas) : IJobPositionService
{
    public async Task<BaseProcess<List<JobPositionModel>>> GetAllJobPositionAsync(PagedRequest request, CancellationToken cancellationToken)
    {
        var data = await jobPositionDas.GetAllAsync(request, cancellationToken);

        var jobPositionModels = data.Items.Select(p => new JobPositionModel
        {
            Id = p.Id,
            Key = p.Key,
            Value = p.Value,
            DepartmentId = p.DepartmentId,
            EffectiveDate = p.EffectiveDate,
            ExpirationDate = p.ExpirationDate
        }).ToList();

        return new BaseProcess<List<JobPositionModel>>(jobPositionModels, []);
    }



    public async Task<BaseProcess<Guid>> CreateJobPositionAsync(JobPositionRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var department = await departmentDas.GetByIdAsync(request.DepartmentId, cancellationToken);
        if (department == null)
            errors.Add(ReturnCode.DEPARTMENT_NOT_FOUND.ToErrorCode());
        var jobTitle = await jobTitleDas.GetByIdAsync(request.TitleId, cancellationToken);
        if (jobTitle == null)
            errors.Add(ReturnCode.JOB_TITLE_NOT_FOUND.ToErrorCode());
        if (errors.Count != 0) return new BaseProcess<Guid>(Guid.Empty, errors);

        var jobPosition = MapperHelper.CreateEntity<JobPosition>(request);
        jobPosition.Group = PredefineGroups.JobPosition;
        jobPosition.Status = StatusConst.Active;
        jobPosition.CreatedAt = DateTimeOffset.UtcNow;
        await jobPositionDas.AddAsync(jobPosition, cancellationToken);
        return new BaseProcess<Guid>(jobPosition.Id, errors);
    }

    public async Task<BaseProcess<JobPositionModel>> UpdateJobPositionAsync(Guid id, JobPositionModel request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var department = await departmentDas.GetByIdAsync(request.DepartmentId, cancellationToken);
        if (department == null)
            errors.Add(ReturnCode.DEPARTMENT_NOT_FOUND.ToErrorCode());
        var jobTitle = await jobTitleDas.GetByIdAsync(request.TitleId, cancellationToken);
        if (jobTitle == null)
            errors.Add(ReturnCode.JOB_TITLE_NOT_FOUND.ToErrorCode());
        var jobPosition = await jobPositionDas.GetByIdAsync(id, cancellationToken);
        if (jobPosition == null)
            errors.Add(ReturnCode.JOB_POSITION_NOT_FOUND.ToErrorCode());
        if (errors.Count != 0) return new BaseProcess<JobPositionModel>(request, errors);

        MapperHelper.UpdateEntity(jobPosition, request);
        if (jobPosition == null) return new BaseProcess<JobPositionModel>(request, errors);
        jobPosition.UpdatedAt = DateTimeOffset.UtcNow;
        await jobPositionDas.UpdateAsync(id, jobPosition, cancellationToken);

        return new BaseProcess<JobPositionModel>(request, errors);
    }

    public async Task<BaseProcess<Guid>> DeleteJobPositionAsync(Guid id, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var jobPosition = await jobPositionDas.GetByIdAsync(id, cancellationToken);
        if (jobPosition == null)
            errors.Add(ReturnCode.JOB_POSITION_NOT_FOUND.ToErrorCode());
        if (errors.Count == 0)
        {
            await jobPositionDas.DeleteAsync(id, cancellationToken);
        }
        return new BaseProcess<Guid>(id, errors);
    }

    public async Task<BaseProcess<JobPositionModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var department = await jobPositionDas.GetByIdAsync(id, cancellationToken);
        return new BaseProcess<JobPositionModel>(MapperHelper.MapToModel<JobPositionModel>(department), []);
    }
}
