using AutoMapper;
using Database.Files;
using Domain.Infrastructure;
using DTOs.Files;
using Interfaces.Files;

namespace Domain.File
{
    public class FileService : BaseService, IFileService
    {
        private readonly IFileRepository _fileRepo;
        public FileService(IMapper mapper, IFileRepository fileRepo) : base(mapper)
        {
            _fileRepo = fileRepo;
        }

        public FileConfigurationDto GetConfiguration(int clientId) => Mapper.Map<FileConfiguration, FileConfigurationDto>(_fileRepo.Get(clientId));

        public int Create(FileConfigurationDto fileConfig) => _fileRepo.Add(Mapper.Map<FileConfigurationDto, FileConfiguration>(fileConfig));

        public int Update(FileConfigurationDto fileConfig) => _fileRepo.Update(Mapper.Map<FileConfigurationDto, FileConfiguration>(fileConfig));

        public int Delete(int id) => _fileRepo.Delete(id);
    }
}
