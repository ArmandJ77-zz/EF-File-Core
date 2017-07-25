using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.ServiceExtensions
{
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework
            (this IServiceCollection services, string path)
        {
            services.AddDbContext<EfFileCoreContext>(options =>
                options.UseSqlServer(path));

            return services;
        }
    }
}
