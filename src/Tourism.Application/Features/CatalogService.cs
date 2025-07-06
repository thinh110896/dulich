using FluentValidation;
using Tourism.Application.Interfaces;
using Tourism.Domain.Entities;
using Tourism.Domain.Services;
using Tourism.Domain.Shared;
using Tourism.Domain.Helpers;
using Tourism.Shared.Models.Predefine;
using Tourism.Shared.Models;

namespace Tourism.Application.Features;

public class CatalogService(IPredefineDataDas predefineDataDas, IValidator<PredefineDataModel> validatorRequest) : ICatalogService
{

    public async Task<BaseProcess<Dictionary<string, List<PredefineDataRequest>>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var dataDictionary = await predefineDataDas.GetAllAsync(cancellationToken);

        var result = dataDictionary.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(d => new PredefineDataRequest
            {
                Id = d.Id,
                Key = d.Key,
                Value = d.Value,
                Group = d.Group
            }).ToList()
        );

        return new BaseProcess<Dictionary<string, List<PredefineDataRequest>>>(result, new List<Error>());
    }


    public async Task<BaseProcess<Guid>> CreateAsync(PredefineDataModel request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var validator = await validatorRequest.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
        {
            errors.AddRange(validator.Errors.Select(error => new Error(ReturnCode.REQUEST_INVALID, error.ErrorMessage)));
            return new BaseProcess<Guid>(Guid.Empty, errors);
        }
        request.Key = request.Key;
        if (errors.Count != 0) return new BaseProcess<Guid>(Guid.Empty, errors);
        var predefineData = MapperHelper.CreateEntity<PredefineData>(request);
        predefineData.CreatedAt = DateTimeOffset.UtcNow;
        predefineData.Group = request.Group;
        predefineData.Status = StatusConst.Active;
        await predefineDataDas.AddAsync(predefineData, cancellationToken);
        return new BaseProcess<Guid>(predefineData.Id, errors);
    }

    public async Task<BaseProcess<PredefineDataModel>> UpdateAsync(Guid id, PredefineDataRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var predefineData = await predefineDataDas.GetByIdAsync(id, request.Group, cancellationToken);
        if (predefineData == null)
        {
            errors.Add(ReturnCode.CATALOG_NOT_FOUND.ToErrorCode());
            return new BaseProcess<PredefineDataModel>(request, errors);
        }
        predefineData.UpdatedAt = DateTimeOffset.UtcNow;
        predefineData.Key = request.Key;
        predefineData.Value = request.Value;
        await predefineDataDas.UpdateAsync(id, predefineData, cancellationToken);
        return new BaseProcess<PredefineDataModel>(request, errors);
    }

    public async Task<BaseProcess<Guid>> DeleteAsync(Guid id, string predefineGroup, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var predefineData = await predefineDataDas.GetByIdAsync(id, predefineGroup, cancellationToken);
        if (predefineData == null)
            errors.Add(ReturnCode.CATALOG_NOT_FOUND.ToErrorCode());
        if (errors.Count == 0)
        {
            if (predefineData != null)
            {
                await predefineDataDas.DeleteAsync(predefineData, cancellationToken);
            }
        }
        return new BaseProcess<Guid>(id, errors);
    }

    public async Task<BaseProcess<PredefineDataModel>> GetByIdAsync(Guid id, string predefineGroup, CancellationToken cancellationToken)
    {
        var department = await predefineDataDas.GetByIdAsync(id, predefineGroup, cancellationToken);
        return new BaseProcess<PredefineDataModel>(MapperHelper.MapToModel<PredefineDataModel>(department), []);
    }
}