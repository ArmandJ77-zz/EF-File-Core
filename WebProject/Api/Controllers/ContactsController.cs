using DTOs.DataScrape;
using Enums;
using Interfaces.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public JsonResult ImportGeneratedContacts([FromBody] ScrapeDto dto) => Json(_contactService.ImportData(dto));

        [HttpGet]
        public JsonResult ImportStagingContacts([FromQuery] int ClientId) => Json(_contactService.ImportStaging(ClientId));

        [HttpGet]
        public JsonResult ExportStagingContacts([FromQuery] int ClientId) => Json(_contactService.ExportStaging(ClientId));
        

        [HttpGet]
        public JsonResult ExportContacts()
        {
            return Json("");
        }

        

        [HttpGet]
        public JsonResult ImportContacts() {
            return Json("");
        }
    }
}