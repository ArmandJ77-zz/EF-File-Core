using DTOs.Clients;
using System.Collections.Generic;

namespace Interfaces.Clients
{
    public interface IClientService
    {
        List<ClientDto> GetAll();
        ClientDto Get(int Id);
        int Delete(int id);
        int Add(ClientDto dto);
        int Update(ClientDto dto);
    }
}
