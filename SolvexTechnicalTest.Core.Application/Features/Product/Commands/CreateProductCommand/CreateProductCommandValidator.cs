using FluentValidation;
using SolvexTechnicalTest.Core.Application.Common;
using SolvexTechnicalTest.Core.Application.Interfaces.Services.ReadsServices;


namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(IColorReadService colorReadService) 
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("the name canont not empty")
                .NotNull().WithMessage("the name canont not null")
                .MaximumLength(50).WithMessage("the maximum is 50 characters")
                .MinimumLength(3).WithMessage("the minimun is 3 characters");

            RuleFor(d => d.Description)
                .MaximumLength(250).WithMessage("the maximum is 250 characters")
                .MinimumLength(0).WithMessage("the minimum is 0 characters");

            RuleFor(d => d.ImageUrl)
                .MaximumLength(250).WithMessage("the maximum is 250 characters")
                .MinimumLength(0).WithMessage("the minimum is 0 characters")
                .ValidImageUrl();

        }
    }
}
