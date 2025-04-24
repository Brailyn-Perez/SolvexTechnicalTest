using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("the Id canont not empty")
                .NotNull().WithMessage("the Id canont not null");

        }
    }
}
