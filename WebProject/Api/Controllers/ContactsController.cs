using DTOs.DataScrape;
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
        public JsonResult ImportData([FromBody] ScrapeDto dto) => Json(_contactService.ImportData(dto));

        
    }
}