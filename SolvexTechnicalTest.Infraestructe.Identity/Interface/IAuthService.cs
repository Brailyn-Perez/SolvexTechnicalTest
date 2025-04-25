using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Interface
{
    public interface IAuthService
    {
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        Task<bool> ValidateUserCredentialsAsync(string email, string password);
    }
}
