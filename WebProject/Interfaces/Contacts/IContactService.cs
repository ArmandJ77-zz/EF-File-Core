using Database.Contacts;
using DTOs.DataScrape;
using System.Collections.Generic;

namespace Interfaces.Contacts
{
    public interface IContactService
    {
        List<ImportedContact> GetImported(int ClientId);
        List<Contact> Get(int ClientId);
        string ImportData(ScrapeDto dto);
    }
}
