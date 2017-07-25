using Domain.Clients;
using Domain.Contacts;
using Domain.File;
using Infrastructure;
using Interfaces.Clients;
using Interfaces.Contacts;
using Interfaces.Files;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.ServiceExtensions
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddTransient<IApiClient, ApiClient>();

            services.AddTransient<IFileService,FileService>();
            services.AddTransient<IFileRepository, FileRepository>();

            return services;
        }
    }
}
