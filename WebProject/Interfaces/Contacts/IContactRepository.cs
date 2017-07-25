using Database.Contacts;
using System.Collections.Generic;

namespace Interfaces.Contacts
{
    public interface IContactRepository
    {
        List<ImportedContact> GetImported(int clientId);
        List<Contact> Get(int ClientId);

        int Add(ImportedContact contact, int ClientId);
        int Add(Contact contact);

    }
}
