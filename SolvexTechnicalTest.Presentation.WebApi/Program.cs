using SolvexTechnicalTest.IOC.ApplicationLayer;
using SolvexTechnicalTest.IOC.PersistenceLayer;
using SolvexTechnicalTest.Presentation.WebApi.Extensions;

namespace SolvexTechnicalTest.Presentation.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
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


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
            app.UserErrorHandlingMiddleware();

            app.Run();
        }
    }
}
