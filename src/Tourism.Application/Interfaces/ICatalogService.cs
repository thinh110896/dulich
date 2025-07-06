using Tourism.Domain.Services;
using Tourism.Shared.Models;
using Tourism.Shared.Models.Predefine;

namespace Tourism.Application.Interfaces;

public interface ICatalogService : IBaseService
{
    Task<BaseProcess<Dictionary<string, List<PredefineDataRequest>>>> GetAllAsync(CancellationToken cancellationToken);
    Task<BaseProcess<PredefineDataModel>> GetByIdAsync(Guid id, string predefineGroup, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> CreateAsync(PredefineDataModel request, CancellationToken cancellationToken);
    Task<BaseProcess<PredefineDataModel>> UpdateAsync(Guid id, PredefineDataRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<Guid>> DeleteAsync(Guid id, string predefineGroup, CancellationToken cancellationToken);
}