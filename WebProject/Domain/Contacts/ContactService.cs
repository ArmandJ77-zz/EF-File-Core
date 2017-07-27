using AutoMapper;
using Database.Contacts;
using Domain.FileConfigurations.Builders;
using Domain.Infrastructure;
using DTOs.Contacts;
using DTOs.DataScrape;
using DTOs.Settings;
using Infrastructure;
using Interfaces.Clients;
using Interfaces.Contacts;
using Interfaces.FileConfiguration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Collections;
using Enums;

namespace Domain.Contacts
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IClientService _clientService;
        private readonly IFileConfigurationService _fileService;
        private readonly IContactRepository _contactRepo;
        private readonly IApiClient _apiClient;
        private readonly IOptions<AppSettingsDto> _settings;

        public ContactService(IContactRepository contactRepo,IMapper mapper, IClientService clientService,
          IFileConfigurationService fileService,
          IApiClient apiClient,
          IOptions<AppSettingsDto> settings) : base(mapper)
        {
            _contactRepo = contactRepo;
            _apiClient = apiClient;
            _settings = settings;
            _clientService = clientService;
            _fileService = fileService;
        }

        public List<ImportedContact> GetImported(int clientId) => _contactRepo.GetImported(clientId);
        public List<Contact> Get(int clientId) => _contactRepo.Get(clientId);

        public string ImportData(ScrapeDto dto)
        {
            if (dto.ClientId < 0)
                return "Invalid contactId";

            var urlparams = $"?amount={dto.Count}&region={dto.Country}&ext";

            var response = _apiClient.Get(_settings.Value.ApiUrls.Url, urlparams);

            if (response.StatusCode != HttpStatusCode.OK)
                return $"Data retrieval failed form: {_settings.Value.ApiUrls.Url}{urlparams}";

            var importedContactsList = JsonConvert.DeserializeObject<List<ImportedContactsDto>>(response.Content);

            if (importedContactsList == null || importedContactsList.Count == 0)
                return "No Contacts imported from external api";

            var data = Mapper.Map<List<ImportedContactsDto>, List<ImportedContact>>(importedContactsList);

            data.ForEach(item =>
            {
                _contactRepo.Add(item, dto.ClientId);
            });

            return $"{data.Count} Contacts Imported";
        }

        public string ImportStaging(int clientId)
        {
            var client = _clientService.Get(clientId);

            if (client == null)
                return "Client not found";

            var fileConfig = _fileService.GetConfiguration(clientId);

            if (fileConfig == null)
                return $"File configuration not found for client {clientId}";

            if (string.IsNullOrEmpty(fileConfig.OutputPath))
                return $"No output file configuration found for Client: {clientId}";

            var list = GetImported(clientId);

            var writeFunc = new Dictionary<FileType, Func<List<string>>> {
                {FileType.CSV, () =>  CSVBuilder.ReadFromCsvFile(fileConfig.InputPath)},
                {FileType.JSON, () =>  JsonBuilder.ReadFromJsonFile(fileConfig.InputPath)}
            };

            var data = writeFunc[fileConfig.FileType].Invoke();

            if (data == null)
                return "Import Failed";

            var dto = Mapper.Map<List<string>, List<ImportedContact>>(data);

            dto.ForEach(item =>
            {
                _contactRepo.Add(item, clientId);
            });

            return $"Imported {dto.Count} contacts";            
        }

        public string ExportStaging(int clientId)
        {
            var client = _clientService.Get(clientId);

            if (client == null)
                return "Client not found";

            var fileConfig = _fileService.GetConfiguration(clientId);

            if (fileConfig == null)
                return $"File configuration not found for client {clientId}";

            if (string.IsNullOrEmpty(fileConfig.OutputPath))
                return $"No output file configuration found for Client: {clientId}";

            var list = GetImported(clientId);

            var writeFunc = new Dictionary<FileType, Func<string>> {
                {FileType.CSV, () =>  CSVBuilder.WriteToCsv(list, fileConfig.OutputPath)},
                {FileType.JSON, () =>  JsonBuilder.WriteToJson(list,fileConfig.OutputPath)}

            };

            return writeFunc[fileConfig.FileType].Invoke();
        }
    }
}
