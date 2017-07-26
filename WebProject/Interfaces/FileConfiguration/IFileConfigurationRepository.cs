using Database.Files;

namespace Interfaces.FileConfiguration
{
    public interface IFileConfigurationRepository
    {
        ClientFileConfiguration Get(int clientId);
        int Add(ClientFileConfiguration fileConfiguration);
        int Update(ClientFileConfiguration fileConfiguration);
        int Delete(int id);
    }
}
