using Database;
using Database.Clients;
using Domain.Infrastructure;
using Interfaces.Clients;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Clients
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(EfFileCoreContext context) : base(context)
        {
            _context = context;
        }

        public List<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client Get(int id)
        {
            return _context.Clients
                .SingleOrDefault(x => x.ClientId == id);
        }

        public int Create(Client client) {
            _context.Add(client);
            _context.SaveChanges();
            return client.ClientId;
        }

        public int Delete(int id)
        {
            var client = _context.Clients.SingleOrDefault(x => x.ClientId == id);

            if (client == null)
                return id;

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return id;
        }        
    }
}
