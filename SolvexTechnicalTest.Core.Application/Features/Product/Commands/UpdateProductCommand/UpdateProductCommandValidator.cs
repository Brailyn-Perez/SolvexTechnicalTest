using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(i => i.Id)
                .LessThanOrEqualTo(0).WithMessage("")
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("");

            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("")
                .MaximumLength(50).WithMessage("")
                .MinimumLength(3).WithMessage("");

            RuleFor(d => d.Description)
                .MaximumLength(250).WithMessage("")
                .MinimumLength(0).WithMessage("");            
            
            RuleFor(d => d.ImageUrl)
                .MaximumLength(250).WithMessage("")
                .MinimumLength(0).WithMessage("");
        }
    }
}
