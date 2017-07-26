using Database;
using Database.Files;
using Domain.Infrastructure;
using Interfaces.FileConfiguration;
using System.Linq;

namespace Domain.FileConfigurations
{
    public class FileConfigurationRepository : BaseRepository, IFileConfigurationRepository
    {
        public FileConfigurationRepository(EfFileCoreContext context) : base(context)
        {
            _context = context;
        }

        public ClientFileConfiguration Get(int clientId) => _context.ClientFileConfiguration.SingleOrDefault(x => x.ClientId == clientId);

        public int Add(ClientFileConfiguration fileConfiguration)
        {
            _context.Add(fileConfiguration);
            _context.SaveChanges();
            return fileConfiguration.ClientId;
        }

        public int Update(ClientFileConfiguration fileConfiguration)
        {
            if (fileConfiguration == null)
                return -1;

            _context.Update(fileConfiguration);
            _context.SaveChanges();

            return fileConfiguration.ClientFileConfigurationId;
        }

        public int Delete(int id)
        {
            var entity = _context.ClientFileConfiguration.SingleOrDefault(x => x.ClientFileConfigurationId == id);

            if (entity == null)
                return id;

            _context.ClientFileConfiguration.Remove(entity);
            _context.SaveChanges();

            return id;
        }
    }
}
