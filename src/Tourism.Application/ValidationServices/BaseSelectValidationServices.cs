using FluentValidation;
using Tourism.Infrastructure;
using Tourism.Shared.Models.Predefine;

namespace Tourism.Application.ValidationServices;

public class BaseSelectValidationServices : AbstractValidator<PredefineDataModel>
{
    public BaseSelectValidationServices(TourismDbContext TourismDbContext)
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Value is required")
            .WithMessage("Value must not exceed 100 characters");
        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Key is required")
            .WithMessage("Key must not exceed 100 characters");    
    }
}
