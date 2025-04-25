using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Color.Commands.DeleteColorCommand
{
    public class DeleteColorCommandValidator : AbstractValidator<DeleteColorCommand>
    {
        public DeleteColorCommandValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("the Id cannot be empty")
                .NotNull().WithMessage("the Id cannot be null")
                .GreaterThan(0).WithMessage("the Id must be greater than 0");

        }
    }
}
