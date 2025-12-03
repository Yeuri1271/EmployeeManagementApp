using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Add the service as a singleton to keep the data persistent while the application is running.
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            // User repository + JWT generator
            services.AddSingleton<IUserAppRepository, UserAppRepository>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        } 
    }
}
