using Database;
using Database.Files;
using Domain.Infrastructure;
using Interfaces.Files;
using System.Linq;

namespace Domain.File
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(EfFileCoreContext context) : base(context)
        {
            _context = context;
        }

        public FileConfiguration Get(int clientId) => _context.FileConfigurations.SingleOrDefault(x => x.ClientId == clientId);

        public int Add(FileConfiguration fileConfiguration)
        {
            _context.Add(fileConfiguration);
            _context.SaveChanges();
            return fileConfiguration.ClientId;
        }

        public int Update(FileConfiguration fileConfiguration)
        {
            if (fileConfiguration == null)
                return -1;

            _context.Update(fileConfiguration);
            _context.SaveChanges();

            return fileConfiguration.FileConfigurationId;
        }

        public int Delete(int id)
        {
            var entity = _context.FileConfigurations.SingleOrDefault(x => x.FileConfigurationId == id);

            if (entity == null)
                return id;

            _context.FileConfigurations.Remove(entity);
            _context.SaveChanges();

            return id;
        }
    }
}
