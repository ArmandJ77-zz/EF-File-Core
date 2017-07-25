using Domain.Clients;
using Interfaces.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace WebProject.Infrastructure.ServiceExtensions
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();

            services.AddTransient<IClientRepository, ClientRepository>();
            return services;
        }
    }
}
