using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolvexTechnicalTest.Core.Application.DTOs.Users;
using SolvexTechnicalTest.Core.Application.Interfaces.Identity;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }



        public async Task<List<UserDto>> GetAllAsync()
        {
            return await _userManager.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName
            })
            .ToListAsync();
        }

        public async Task<UserDto?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };
        }
    }
}
