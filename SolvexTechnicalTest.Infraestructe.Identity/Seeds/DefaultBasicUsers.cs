using Microsoft.AspNetCore.Identity;
using SolvexTechnicalTest.Core.Application.Enums;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Seeds
{
    public static class DefaultBasicUsers
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string email = "UserBasic@gmail.com";
            string password = "UserBasic@123";
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

                if (!result.Succeeded)
                {
                    Console.WriteLine($"Error creating user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    return;
                }

                if (!await roleManager.RoleExistsAsync(Roles.Admin.ToString()))
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                    if (!roleResult.Succeeded)
                    {
                        Console.WriteLine($"Error creating role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                        return;
                    }
                }

                await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
            }
        }

    }
}
