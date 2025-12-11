using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using First.Ecard.Application.Interfaces;
using First.Ecard.Infrastructure.Repositories;
using First.Ecard.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace First.Ecard.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FirstDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
            
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}