using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Database
{
    public class AppDbContextFactory : IDbContextFactory<EfFileCoreContext>
    {
        public EfFileCoreContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<EfFileCoreContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=FileEFCore;Integrated Security=True",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(EfFileCoreContext).GetTypeInfo().Assembly.GetName().Name));
            return new EfFileCoreContext(builder.Options);
        }
    }
}
