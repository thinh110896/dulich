using Tourism.Domain.Entities;
using Tourism.Domain.Services;
using Tourism.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tourism.Shared.Models.Predefine;

public class PredefineDataDas(TourismDbContext infraDbContext) : IPredefineDataDas
{
    public async Task<Dictionary<string, List<PredefineData>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var groups = new List<string> { PredefineGroups.MaritalStatus, PredefineGroups.Major, PredefineGroups.EducationLevel, PredefineGroups.Gender, PredefineGroups.Relationship, PredefineGroups.AcademicStandard };

        var predefineDataList = await infraDbContext.PredefineDatas
            .Where(p => groups.Contains(p.Group))
            .Select(p => new PredefineData
            {
                Id = p.Id,
                Key = p.Key,
                Group = p.Group,
                Value = p.Value
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var groupedData = predefineDataList
            .GroupBy(p => p.Group)
            .ToDictionary(g => g.Key, g => g.ToList());

        return groupedData;
    }

    public async Task<PredefineData> GetByIdAsync(Guid id, string predefineGroup, CancellationToken cancellationToken)
    {
        var predefineData = await infraDbContext.PredefineDatas
            .Where(p => p.Id == id && p.Group == predefineGroup)
            .AsNoTracking()
            .Select(p => new PredefineData { Id = p.Id, Group = p.Group, Key = p.Key, Value = p.Value, Status = p.Status, CreatedAt =  p.CreatedAt,CreatedBy = p.CreatedBy })
            .FirstOrDefaultAsync();
        return predefineData;
    }

    public async Task AddAsync(PredefineData PredefineDataModel, CancellationToken cancellationToken)
    {
        infraDbContext.PredefineDatas.Add(PredefineDataModel);
        await infraDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid id, PredefineData predefineData, CancellationToken cancellationToken)
    {
        infraDbContext.PredefineDatas.Update(predefineData);
        await infraDbContext.SaveChangesAsync(cancellationToken);
    }


    public async Task DeleteAsync(PredefineData predefineData, CancellationToken cancellationToken)
    {
        infraDbContext.PredefineDatas.Remove(predefineData);
        await infraDbContext.SaveChangesAsync(cancellationToken);
    }
}
