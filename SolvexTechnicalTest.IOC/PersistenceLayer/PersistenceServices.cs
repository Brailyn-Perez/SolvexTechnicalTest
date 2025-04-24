using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolvexTechnicalTest.Core.Domain.Repositories;
using SolvexTechnicalTest.Infraestructure.Persistence.Context;
using SolvexTechnicalTest.Infraestructure.Persistence.Repositories;

namespace SolvexTechnicalTest.IOC.PersistenceLayer
{
    public static class IdentityServices
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));


            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            #endregion
        }
    }
}
