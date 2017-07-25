using DTOs.Files;

namespace Interfaces.Files
{
    public interface IFileService
    {
        FileConfigurationDto GetConfiguration(int clientId);
        int Create(FileConfigurationDto fileConfig);
        int Update(FileConfigurationDto fileConfig);
        int Delete(int id);
    }
}
