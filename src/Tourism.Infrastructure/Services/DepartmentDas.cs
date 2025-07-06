using System.Text.RegularExpressions;
using Tourism.Domain.Entities;
using Tourism.Domain.Helpers;
using Tourism.Domain.Services;
using Tourism.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tourism.Shared.Models;
using Tourism.Shared;

public class DepartmentDas(TourismDbContext context) : IDepartmentDas
{
    public async Task<PagedResult<Department>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken)
    {
        var departmentPagedResult = await context.Departments.AsNoTracking().AsQueryable().GetPagedListAsync(pagedRequest, cancellationToken);
        return new PagedResult<Department>
        {
            Items = departmentPagedResult.Items.Select(d => new Department
            {
                Id = d.Id,
                Key = d.Key,
                EffectiveDate = d.EffectiveDate,
                ExpirationDate = d.ExpirationDate,
                Status = d.Status,
                Value = d.Value,
                FullName = d.FullName,
                Description = d.Description
            }).ToList(),
            TotalCount = departmentPagedResult.TotalCount,
            Page = departmentPagedResult.Page,
            PageSize = departmentPagedResult.PageSize
        };
    }

    public async Task<Department> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Departments.FindAsync(id, cancellationToken);
    }

    public async Task AddAsync(Department department, CancellationToken cancellationToken)
    {
        context.Departments.Add(department);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, Department Department, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FindAsync([id],cancellationToken);
        if (department != null)
        {
            context.Departments.Update(department);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<string> GenerateDepartmentCodeAsync(string prefix)
    {
        // Tìm các mã có cùng prefix trong DB
        var existingCodes = await context.PredefineDatas
            .Where(d => d.Group == PredefineGroups.Department && d.Key.StartsWith(prefix))
            .Select(d => d.Key)
            .ToListAsync();

        var numberRegex = new Regex($@"^{prefix}(\d+)$");

        int maxNumber = existingCodes
            .Select(code => numberRegex.Match(code))
            .Where(match => match.Success)
            .Select(match => int.Parse(match.Groups[1].Value))
            .DefaultIfEmpty(0)
            .Max();
        // Tạo mã mới
        return $"{prefix}{maxNumber + 1:D3}";
    }


    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var Department = await context.Departments.FindAsync([id], cancellationToken);
        if (Department != null)
        {
            context.Departments.Remove(Department);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
