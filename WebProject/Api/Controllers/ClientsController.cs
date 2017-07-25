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
        public JsonResult Get()
        {
            var data = _clientService.GetAll();
            return Json(data);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var response = _clientService.Get(id);
            return Json(response);
        }

        [HttpPost]
        public JsonResult Add([FromBody]ClientDto client)
        {
            var response = _clientService.Add(client);
            return Json(response);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return Json(_clientService.Delete(id));
        }
    }
}
