using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices
            (this IServiceCollection services)
        {
            return services;
        }
    }
}
