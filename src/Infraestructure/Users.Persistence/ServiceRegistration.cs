using Microsoft.Extensions.DependencyInjection;
using Users.Application.Abstractions;
using Users.Persistence.Data;
using Users.Persistence.Repositories;

namespace Users.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IUserData, UserData>();

            return services;
        }
    }
}
