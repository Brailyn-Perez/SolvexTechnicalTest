using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolvexTechnicalTest.Infraestructe.Identity.Context;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;
using SolvexTechnicalTest.Infraestructe.Identity.Seeds;
using SolvexTechnicalTest.IOC.ApplicationLayer;
using SolvexTechnicalTest.IOC.IdentityLayer;
using SolvexTechnicalTest.IOC.PersistenceLayer;
using SolvexTechnicalTest.Presentation.WebApi.Extensions;

namespace SolvexTechnicalTest.Presentation.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationLayer();
            builder.Services.AddApiVersioningExtension();
            builder.Services.AddIdentityServices(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UserErrorHandlingMiddleware();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await DefaultRoles.SeedAsync(userManager, roleManager);
                    await DefaultAdminUser.SeedAsync(userManager, roleManager);
                    await DefaultBasicUsers.SeedAsync(userManager, roleManager);
                    await DefaultSellerUser.SeedAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error seeding data: {ex.Message}");
                }
            }

            app.Run();
        }
    }
}
