using Api.Infrastructure.ServiceExtensions;
using Database;
using DTOs.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;

namespace Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.Configure<AppSettingsDto>(Configuration.GetSection("AppSettings"));

            services.AddAutoMapperConfiguration(GetType().GetTypeInfo().Assembly.GetReferencedAssemblies().Select(c => Assembly.Load(c)).ToArray());
            services.AddEntityFramework(Configuration.GetSection("AppSettings:ConnectionStrings:LocalDb").Value);
            services.AddDomain();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
          .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<EfFileCoreContext>().Database.Migrate();
                //serviceScope.ServiceProvider.GetService<ISeedService>().SeedDatabase().Wait();
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseBrowserLink();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
