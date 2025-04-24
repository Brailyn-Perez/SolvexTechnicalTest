using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(i => i.Id)
                .LessThanOrEqualTo(0).WithMessage("")
                .NotEmpty().WithMessage("")
                .NotNull().WithMessage("");
        
        }
    }
}
