using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using First.Ecard.Application.Behaviors;
using First.Ecard.Application.Interfaces;

namespace First.Ecard.Application
{
    public static class ApplicationRegistrationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationRegistrationService).Assembly);
            services.AddValidatorsFromAssembly(typeof(ApplicationRegistrationService).Assembly);
            services.AddMediatR(typeof(ApplicationRegistrationService).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}