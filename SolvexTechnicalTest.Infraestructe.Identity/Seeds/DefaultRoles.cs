using Microsoft.AspNetCore.Identity;
using SolvexTechnicalTest.Core.Application.Enums;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Seller.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}
