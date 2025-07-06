using Tourism.Domain.Entities;
using Tourism.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Tourism.Shared.Models;
using Tourism.Shared;

namespace Tourism.Infrastructure.Services;
public class JobPositionDas(TourismDbContext infraDbContext) : IJobPositionDas
{
    public async Task<PagedResult<JobPosition>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken)
    {
        var jobPositionPagedResult = await infraDbContext.Positions.AsNoTracking().GetPagedListAsync(pagedRequest, cancellationToken);
        return new PagedResult<JobPosition>
        {
            Items = jobPositionPagedResult.Items.Select(d => new JobPosition
            {
                Id = d.Id,
                Key = d.Key,
                Value = d.Value,
                DepartmentId = d.DepartmentId,
                TitleId = d.TitleId,
                EffectiveDate = d.EffectiveDate,
                ExpirationDate = d.ExpirationDate
            }).ToList(),
            TotalCount = jobPositionPagedResult.TotalCount,
            Page = jobPositionPagedResult.Page,
            PageSize = jobPositionPagedResult.PageSize
        };
    }

    public async Task<JobPosition> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await infraDbContext.Positions.FindAsync([id], cancellationToken);
    }

    public async Task AddAsync(JobPosition JobPosition, CancellationToken cancellationToken)
    {
        infraDbContext.Positions.Add(JobPosition);
        await infraDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<JobPosition> UpdateAsync(Guid id, JobPosition jobPosition, CancellationToken cancellationToken)
    {
        var data = await infraDbContext.Positions.FindAsync([jobPosition.Id], cancellationToken);
        if (data != null)
        {
            infraDbContext.Positions.Update(jobPosition);
            await infraDbContext.SaveChangesAsync(cancellationToken);
            return data;
        }
        return jobPosition;
    }


    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var JobPosition = await infraDbContext.Positions.FindAsync([id], cancellationToken);
        if (JobPosition == null) return false;
        infraDbContext.Positions.Remove(JobPosition);
        await infraDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}