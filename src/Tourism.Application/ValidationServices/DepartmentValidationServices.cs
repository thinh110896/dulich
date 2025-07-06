using FluentValidation;
using Tourism.Application.Models.Dto;
using Tourism.Infrastructure;

namespace Tourism.Application.ValidationServices;

public class DepartmentValidationServices : AbstractValidator<DepartmentRequest>
{
    public DepartmentValidationServices(TourismDbContext TourismDbContext)
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("Full name is required")
            .MaximumLength(100)
            .WithMessage("Full name must not exceed 100 characters");
    }
}
