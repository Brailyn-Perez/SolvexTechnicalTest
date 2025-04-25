using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Features.Authenticate.Command.AuthenticateCommand
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
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

            RuleFor(x => x.IpAddress)
                .NotEmpty()
                .WithMessage("IP Address is required.")
                .Matches(@"^(\d{1,3}\.){3}\d{1,3}$")
                .WithMessage("Invalid IP Address format.");
        }
    }
}
