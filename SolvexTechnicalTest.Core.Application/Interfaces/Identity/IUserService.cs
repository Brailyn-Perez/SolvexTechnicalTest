using SolvexTechnicalTest.Core.Application.DTOs.Users;

namespace SolvexTechnicalTest.Core.Application.Interfaces.Identity
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(string id);
        Task<List<UserDto>> GetAllAsync();
    }
}
