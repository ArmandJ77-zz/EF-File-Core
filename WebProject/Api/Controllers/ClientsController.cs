using DTOs.Clients;
using Interfaces.Clients;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public JsonResult Get() => Json(_clientService.GetAll());
        
        [HttpGet("{id}")]
        public JsonResult Get(int id) =>  Json(_clientService.Get(id));

        [HttpPost]
        public JsonResult Add([FromBody]ClientDto client)=> Json(_clientService.Add(client));

        [HttpPut]
        public JsonResult Update([FromBody] ClientDto client) => Json(_clientService.Update(client));

        [HttpDelete("{id}")]
        public JsonResult Delete(int id) => Json(_clientService.Delete(id));
    }
}
