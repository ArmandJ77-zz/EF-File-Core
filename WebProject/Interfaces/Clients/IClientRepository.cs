using Database.Clients;
using System.Collections.Generic;

namespace Interfaces.Clients
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client Get(int id);
        int Delete(int id);
        int Create(Client client);
    }
}
