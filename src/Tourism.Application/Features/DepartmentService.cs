using FluentValidation;
using Tourism.Application.Interfaces;
using Tourism.Domain.Entities;
using Tourism.Domain.Helper;
using Tourism.Domain.Services;
using Tourism.Domain.Shared;
using System.Globalization;
using Tourism.Domain.Helpers;
using Tourism.Shared.Models;
using Tourism.Application.Models.Dto;

namespace Tourism.Application.Features;

public class DepartmentService(IDepartmentDas departmentDas, IValidator<DepartmentRequest> validatorDepartmentRequest) : IDepartmentService
{
    public async Task<BaseProcess<List<DepartmentModel>>> GetAllDepartmentAsync(PagedRequest request, CancellationToken cancellationToken)
{
    var data = await departmentDas.GetAllAsync(request, cancellationToken);

    var departmentModels = data.Items.Select(d => new DepartmentModel
    {
        Id = d.Id,
        Key = d.Key,
        Value = d.Value,
        Group = d.Group,
        Description = d.Description,
        Status = d.Status,
        FullName = d.FullName,
        EffectiveDate = d.EffectiveDate,
        ExpirationDate = d.ExpirationDate
    }).ToList();

    return new BaseProcess<List<DepartmentModel>>(departmentModels, []);
}


    public async Task<BaseProcess<Guid>> CreateDepartmentAsync(DepartmentRequest request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var validator = await validatorDepartmentRequest.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
        {
            errors.AddRange(validator.Errors.Select(error => new Error(ReturnCode.DEPARTMENT_INVALID, error.ErrorMessage)));
            return new BaseProcess<Guid>(Guid.Empty, errors);
        }
        var codeDepartment = await departmentDas.GenerateDepartmentCodeAsync(GetCodePrefix(request.Value));
        request.Key = codeDepartment;
        if (errors.Count != 0) return new BaseProcess<Guid>(Guid.Empty, errors);
        var department = MapperHelper.CreateEntity<Department>(request);
        department.CreatedAt = DateTimeOffset.UtcNow;
        department.Group = PredefineGroups.Department;
        department.Status = StatusConst.Active;
        department.Description = request.Description != null ? CommonHelper.StripHTML(request.Description) : string.Empty;
        await departmentDas.AddAsync(department, cancellationToken);
        return new BaseProcess<Guid>(department.Id, errors);
    }

    private string GetCodePrefix(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Department name cannot be empty.");
        // Loại bỏ dấu, lấy chữ cái đầu của mỗi từ
        var normalized = RemoveDiacritics(name.ToUpper());
        return string.Concat(normalized.Split(' ')
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .Select(word => word[0])); // Lấy chữ cái đầu
    }
    private static string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
        return new string(normalizedString.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray());
    }

    public async Task<BaseProcess<DepartmentModel>> UpdateDepartmentAsync(Guid id, DepartmentModel request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var department = await departmentDas.GetByIdAsync(id, cancellationToken);
        if (department == null)
        {
            errors.Add(ReturnCode.DEPARTMENT_NOT_FOUND.ToErrorCode());
            return new BaseProcess<DepartmentModel>(request, errors);
        }
        MapperHelper.UpdateEntity(department, request);
        department.UpdatedAt = DateTimeOffset.UtcNow;
        await departmentDas.UpdateAsync(id, department, cancellationToken);
        return new BaseProcess<DepartmentModel>(request, errors);
    }

    public async Task<BaseProcess<Guid>> DeleteDepartmentAsync(Guid id, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();
        var department = await departmentDas.GetByIdAsync(id, cancellationToken);
        if (department == null)
            errors.Add(ReturnCode.DEPARTMENT_NOT_FOUND.ToErrorCode());
        if (errors.Count == 0)
        {
            await departmentDas.DeleteAsync(id, cancellationToken);
        }
        return new BaseProcess<Guid>(id, errors);
    }

    public async Task<BaseProcess<DepartmentModel>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var department = await departmentDas.GetByIdAsync(id, cancellationToken);
        return new BaseProcess<DepartmentModel>(MapperHelper.MapToModel<DepartmentModel>(department), []);
    }
}