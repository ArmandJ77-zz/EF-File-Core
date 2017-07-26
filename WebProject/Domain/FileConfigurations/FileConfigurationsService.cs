using AutoMapper;
using Database.Files;
using Domain.Infrastructure;
using DTOs.Files;
using Interfaces.FileConfiguration;

namespace Domain.FileConfigurations
{
    public class FileConfigurationsService : BaseService, IFileConfigurationService
    {
        private readonly IFileConfigurationRepository _fileRepo;
        public FileConfigurationsService(IMapper mapper, IFileConfigurationRepository fileRepo) : base(mapper)
        {
            _fileRepo = fileRepo;
        }

        public FileConfigurationDto GetConfiguration(int clientId) => Mapper.Map<ClientFileConfiguration, FileConfigurationDto>(_fileRepo.Get(clientId));

        public int Create(FileConfigurationDto fileConfig) => _fileRepo.Add(Mapper.Map<FileConfigurationDto, ClientFileConfiguration>(fileConfig));

        public int Update(FileConfigurationDto fileConfig) => _fileRepo.Update(Mapper.Map<FileConfigurationDto, ClientFileConfiguration>(fileConfig));

        public int Delete(int id) => _fileRepo.Delete(id);

    }
}
