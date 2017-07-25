using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interfaces.Clients;
using DTOs.Clients;
using ViewModels;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientservice;
        public HomeController(IClientService clientservice)
        {
            _clientservice = clientservice;
        }
        public IActionResult Index()
        {
            return View(new ClientViewModel());
        }

        public IActionResult AddClient(ClientViewModel data)
        {
            var result = _clientservice.Add(data.CreateClient);
            //var foo = _clientservice.Build();
            //return View(@"~/Views/Home/Index.cshtml", foo);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
