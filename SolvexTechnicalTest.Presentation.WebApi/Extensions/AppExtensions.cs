using SolvexTechnicalTest.Presentation.WebApi.Middlewares;

namespace SolvexTechnicalTest.Presentation.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UserErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
