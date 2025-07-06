using Tourism.Domain.Entities;
using Tourism.Domain.Helpers;
using Tourism.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Tourism.Shared.Models;
using Tourism.Shared;

namespace Tourism.Infrastructure.Services;

public class JobTitleDas(TourismDbContext infraDbContext) : IJobTitleDas
{
    public async Task<PagedResult<JobTitle>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken)
    {
        var jobTitlePagedResult = await infraDbContext.Titles.AsNoTracking().GetPagedListAsync(pagedRequest, cancellationToken);
        return new PagedResult<JobTitle>
        {
            Items = jobTitlePagedResult.Items.Select(d => new JobTitle
            {
                Id = d.Id,
                Key = d.Key,
                Value = d.Value,
                DepartmentId = d.DepartmentId,
                EffectiveDate = d.EffectiveDate,
                ExpirationDate = d.ExpirationDate
            }).ToList(),
            TotalCount = jobTitlePagedResult.TotalCount,
            Page = jobTitlePagedResult.Page,
            PageSize = jobTitlePagedResult.PageSize
        };
    }

    public async Task<JobTitle?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await infraDbContext.Titles.FindAsync([id], cancellationToken);
    }

    public async Task AddAsync(JobTitle jobTitle, CancellationToken cancellationToken)
    {
        infraDbContext.Titles.Add(jobTitle);
        await infraDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<JobTitle> UpdateAsync(Guid id, JobTitle jobTitle, CancellationToken cancellationToken)
    {
        var data = await infraDbContext.Titles.FindAsync([jobTitle.Id], cancellationToken: cancellationToken);
        if (data == null) return jobTitle;
        infraDbContext.Titles.Update(jobTitle);
        await infraDbContext.SaveChangesAsync(cancellationToken);
        return data;
    }


    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var jobTitle = await infraDbContext.Titles.FindAsync([id], cancellationToken);
        if (jobTitle != null)
        {
            infraDbContext.Titles.Remove(jobTitle);
            await infraDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}