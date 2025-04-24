using Microsoft.AspNetCore.Identity;
using SolvexTechnicalTest.Core.Application.Enums;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;

namespace SolvexTechnicalTest.Infraestructe.Identity.Seeds
{
    public static class DefaultSellerUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string email = "UserSeller@gmail.com";
            string password = "UserSeller@123";
            string userName = "UserSeller";

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ApplicationUser defaultUser = new()
                {
                    UserName = userName,
                    Email = email,
                    FirstName = "UserSeller",
                    LastName = "Seller Last Name",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var result = await userManager.CreateAsync(defaultUser, password);

                if (!result.Succeeded)
                {
                    Console.WriteLine($"Error creating user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    return;
                }

                if (!await roleManager.RoleExistsAsync(Roles.Seller.ToString()))
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(Roles.Seller.ToString()));
                    if (!roleResult.Succeeded)
                    {
                        Console.WriteLine($"Error creating role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                        return;
                    }
                }

                var addToRoleResult = await userManager.AddToRoleAsync(defaultUser, Roles.Seller.ToString());
                if (!addToRoleResult.Succeeded)
                {
                    Console.WriteLine($"Error adding user to role: {string.Join(", ", addToRoleResult.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}
