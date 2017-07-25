using Database;
using Database.Contacts;
using Domain.Infrastructure;
using Interfaces.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Contacts
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(EfFileCoreContext context) : base(context)
        {
            _context = context;
        }

        public List<ImportedContact> GetImported(int clientId) => _context.ImportedContacts.Where(x => x.ClientId == clientId).ToList();
        public List<Contact> Get(int clientId) => _context.Contacts.Where(x => x.ClientId == clientId).ToList();

        public int Add(ImportedContact contact, int clientId)
        {
            var client = _context.Clients.SingleOrDefault(x => x.ClientId == clientId);

            contact.ClientId = client.ClientId;
            contact.Client = client;

            _context.Add(contact);
            _context.SaveChanges();

            return contact.ImportedContactId;
        }

        public int Add(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();

            return contact.ContactId;
        }

        

    }
}
