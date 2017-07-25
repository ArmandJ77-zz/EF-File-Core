using DTOs.Clients;
using System.Collections.Generic;

namespace ViewModels
{
    public class ClientViewModel
    {
        public ClientDto CreateClient { get; set; }
        public List<ClientDto> ClientsList { get; set; }

        public ClientViewModel() {
            ClientsList = new List<ClientDto>();
        }
    }
}
