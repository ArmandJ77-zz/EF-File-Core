using Database.Contacts;
using Database.Files;
using Database.Infrastructure;
using System.Collections.Generic;

namespace Database.Clients
{
    public class Client : BaseEntity
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public List<Contact> Contacts { get; set; }
        public List<ImportedContact> ImportedContacts { get; set; }
        public List<ClientFileConfiguration> ClientFileConfiguration { get; set; }        
    }
}