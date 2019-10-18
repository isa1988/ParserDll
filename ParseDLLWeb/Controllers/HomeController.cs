using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParseDLLService.Dtos;
using ParseDLLService.Services;
using ParseDLLService.Services.Contracts;
using ParseDLLWeb.Models;

namespace ParseDLLWeb.Controllers
{
    public class HomeController : Controller
    {
        private IWorkToFile _service;

        public HomeController(IWorkToFile service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FileDllModel request)
        {
            request.Result = _service.ShowMethods(new FileDllDto {Path = request.Path});

            return View(request);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
