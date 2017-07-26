using DTOs.Files;

namespace Interfaces.FileConfiguration
{
    public interface IFileConfigurationService
    {
        FileConfigurationDto GetConfiguration(int clientId);
        int Create(FileConfigurationDto fileConfig);
        int Update(FileConfigurationDto fileConfig);
        int Delete(int id);
    }
}
