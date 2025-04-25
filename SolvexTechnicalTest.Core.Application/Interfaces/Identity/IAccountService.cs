using SolvexTechnicalTest.Core.Application.DTOs.Users;
using SolvexTechnicalTest.Core.Application.Wrappers;

namespace SolvexTechnicalTest.Core.Application.Interfaces.Identity
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
