using FluentValidation;

namespace SolvexTechnicalTest.Core.Application.Common
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string?> ValidImageUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
            .Must(url => string.IsNullOrEmpty(url) || Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            .WithMessage("Image Url must be a valid URL");
        }

        public static IRuleBuilderOptions<T, string> ValidHexCode<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Matches(@"^#([A-Fa-f0-9]{6})$")
                .WithMessage("Hex code must be in the format #RRGGBB.");
        }
    }
}
