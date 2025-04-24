using FluentValidation;
using SolvexTechnicalTest.Core.Application.Common;
using SolvexTechnicalTest.Core.Application.Interfaces.Services.ReadsServices;
using SolvexTechnicalTest.Core.Application.Services;

namespace SolvexTechnicalTest.Core.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator(IColorReadService colorReadService)
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("the Id canont not empty")
                .NotNull().WithMessage("the Id canont not null");

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

            RuleFor(x => x.ColorId)
                .MustAsync(async (colorId, ct) => await colorReadService.ExistsAsync((int)colorId, ct))
                .WithMessage("The specified color does not exist.");
        }
    }
}
