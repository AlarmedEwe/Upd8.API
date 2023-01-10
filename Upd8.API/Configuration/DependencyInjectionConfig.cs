using Upd8.API.Interfaces;
using Upd8.API.Models;
using Upd8.Domain.Core.Interfaces.Repositories;
using Upd8.Domain.Core.Interfaces.Services;
using Upd8.Domain.Services;
using Upd8.Repositories;

namespace Upd8.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Services
            services.AddScoped<ICustomerService, CustomerService>();

            // Configurations
            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
