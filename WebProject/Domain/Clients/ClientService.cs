using AutoMapper;
using Database.Clients;
using Domain.Infrastructure;
using DTOs.Clients;
using Interfaces.Clients;
using System.Collections.Generic;

namespace Domain.Clients
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientRepository _clientRepo;

        public ClientService(IMapper mapper, IClientRepository clientrepo) : base(mapper) {
            _clientRepo = clientrepo;
        }

        public List<ClientDto> GetAll() => Mapper.Map<List<Client>, List<ClientDto>>(_clientRepo.GetAll());

        public ClientDto Get(int Id) => Mapper.Map<Client, ClientDto>(_clientRepo.Get(Id));

        public int Add(ClientDto dto) => _clientRepo.Create(Mapper.Map<ClientDto, Client>(dto));

        public int Update(ClientDto dto) => _clientRepo.Update(Mapper.Map<ClientDto, Client>(dto));

        public int Delete(int id)
        { 
            var result = _clientRepo.Delete(id);
            return id;
        }     
    }
}
