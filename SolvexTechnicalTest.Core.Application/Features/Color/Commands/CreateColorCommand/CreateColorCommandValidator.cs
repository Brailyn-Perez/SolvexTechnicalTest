using FluentValidation;
using SolvexTechnicalTest.Core.Application.Common;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Commands.CreateColorCommand
{
    public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
    {
        public CreateColorCommandValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("the name cannot be empty")
                .NotNull().WithMessage("the name cannot be null")
                .MaximumLength(50).WithMessage("the maximum is 50 characters")
                .MinimumLength(3).WithMessage("the minimum is 3 characters");

            RuleFor(h => h.HexCode)
                .NotEmpty().WithMessage("the hexcode cannot be empty")
                .NotNull().WithMessage("the hexcode cannot be null")
                .MaximumLength(7).WithMessage("the minimum is 7 characters")
                .MinimumLength(7).WithMessage("the minimum is 7 characters")
                .ValidHexCode();

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("the price cannot be empty")
                .NotNull().WithMessage("the price cannot be null");

            RuleFor(i => i.ProductId);

        }
    }
}
