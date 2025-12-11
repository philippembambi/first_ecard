using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace First.Ecard.Application
{
    public static class ApplicationRegistrationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationRegistrationService).Assembly);
            services.AddMediatR(typeof(ApplicationRegistrationService).Assembly);
            return services;
        }
    }
}