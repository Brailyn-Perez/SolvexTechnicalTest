using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Commands.UpdateColorCommand
{
    public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("the Id cannot be empty")
                .NotNull().WithMessage("the Id cannot be null");

            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("the name cannot be empty")
                .NotNull().WithMessage("the name cannot be null")
                .MaximumLength(50).WithMessage("the maximum is 50 characters")
                .MinimumLength(3).WithMessage("the minimum is 3 characters");

            RuleFor(h => h.HexCode)
                .NotEmpty().WithMessage("the hexcode cannot be empty")
                .NotNull().WithMessage("the hexcode cannot be null")
                .MaximumLength(7).WithMessage("the minimum is 7 characters")
                .MinimumLength(7).WithMessage("the minimum is 7 characters");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("the price cannot be empty")
                .NotNull().WithMessage("the price cannot be null");
        }
    }
}
