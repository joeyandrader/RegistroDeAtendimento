using Clinica.Domain.Interfaces;
using Clinica.Infrastructure.Data;
using Clinica.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Clinica.Infrastructure.Ioc
{
    public static class Ioc
    {
        public static void InfraLoadDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserAppointmentRepository, UserAppointmentRepository>();
        }
    }
}
