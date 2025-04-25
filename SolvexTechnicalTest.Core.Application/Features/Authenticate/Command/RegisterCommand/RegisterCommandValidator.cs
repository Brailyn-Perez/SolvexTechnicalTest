using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Authenticate.Command.RegisterCommand
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .MinimumLength(2)
                .WithMessage("First name must be at least 2 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .MinimumLength(2)
                .WithMessage("Last name must be at least 2 characters long.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User name is required.")
                .MinimumLength(3)
                .WithMessage("User name must be at least 3 characters long.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.PasswordConfirmed)
                .NotEmpty()
                .WithMessage("Password confirmation is required.")
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}
