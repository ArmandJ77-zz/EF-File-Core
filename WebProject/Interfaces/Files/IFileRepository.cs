using Database.Files;

namespace Interfaces.Files
{
    public interface IFileRepository
    {
        FileConfiguration Get(int clientId);
        int Add(FileConfiguration fileConfiguration);        
        int Update(FileConfiguration fileConfiguration);
        int Delete(int id);
    }
}
