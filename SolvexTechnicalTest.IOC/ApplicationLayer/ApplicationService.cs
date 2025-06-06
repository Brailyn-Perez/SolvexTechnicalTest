﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SolvexTechnicalTest.Core.Application.Assemblies;
using SolvexTechnicalTest.Core.Application.Behaviours;
using SolvexTechnicalTest.Core.Application.Interfaces.Identity;
using SolvexTechnicalTest.Core.Application.Interfaces.Services.ReadsServices;
using SolvexTechnicalTest.Core.Application.Services;
using SolvexTechnicalTest.Infraestructe.Identity.Service;

namespace SolvexTechnicalTest.IOC.ApplicationLayer
{
    public static class ApplicationService
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddTransient<IColorReadService, ColorReadService>();
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
