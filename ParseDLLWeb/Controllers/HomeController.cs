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
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FileDllModel request)
        {
            IWorkToFile workToFile = new WorkToFile();
            request.Result = workToFile.ShowMethods(new FileDllDto {Path = request.Path});

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
