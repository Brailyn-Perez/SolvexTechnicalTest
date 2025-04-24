using Microsoft.AspNetCore.Identity;
using SolvexTechnicalTest.Core.Application.Enums;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Seeds
{
    public static class DefaultBasicUsers
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            string email = "UserBasic@gmail.com";
            string password = "UserBasicPassword";
            string userName = "UserBasic";

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ApplicationUser defaultUser = new()
                {
                    UserName = userName,
                    Email = email,
                    FirstName = "UserBasic",
                    LastName = "Basic Last Name",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var result = await userManager.CreateAsync(defaultUser, password);

                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync(Roles.Admin.ToString()))
                    {
                        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                    }

                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
    }
}
