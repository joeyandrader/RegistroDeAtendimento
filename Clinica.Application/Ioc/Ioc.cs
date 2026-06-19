using Clinica.Application.Interfaces;
using Clinica.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clinica.Application.Ioc
{
    public static class Ioc
    {
        public static void AppLoadDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserAppointmentService, UserAppointmentService>();
        }
    }
}
