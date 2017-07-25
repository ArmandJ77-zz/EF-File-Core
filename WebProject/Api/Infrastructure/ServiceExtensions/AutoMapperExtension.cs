using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api.Infrastructure.ServiceExtensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services, Assembly[] assemblies) {
            services.AddAutoMapper(assemblies);
            return services;
        }
    }
}
