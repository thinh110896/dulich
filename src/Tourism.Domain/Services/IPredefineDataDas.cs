using Tourism.Domain.Entities;

namespace Tourism.Domain.Services;

public interface IPredefineDataDas : IBaseDas
{
    Task<Dictionary<string, List<PredefineData>>> GetAllAsync(CancellationToken cancellationToken);
    Task<PredefineData> GetByIdAsync(Guid id,string predefineGroup, CancellationToken cancellationToken);
    Task AddAsync(PredefineData PredefineDataModel, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, PredefineData PredefineDataModel, CancellationToken cancellationToken);
    Task DeleteAsync(PredefineData predefineData, CancellationToken cancellationToken);
}
