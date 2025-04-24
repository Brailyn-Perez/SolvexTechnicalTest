using Microsoft.AspNetCore.Identity;
using SolvexTechnicalTest.Core.Application.Enums;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string email = "UserAdmin@gmail.com";
            string password = "UserAdmin@123";
            string userName = "UserAdmin";

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ApplicationUser defaultUser = new()
                {
                    UserName = userName,
                    Email = email,
                    FirstName = "UserAdmin",
                    LastName = "Admin Last Name",
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

                var addToRoleResult = await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                if (!addToRoleResult.Succeeded)
                {
                    Console.WriteLine($"Error adding user to role: {string.Join(", ", addToRoleResult.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
