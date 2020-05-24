using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeterApp.Models;
using PeterApp.Services;

namespace PeterApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly IPaisRepository _IPaisRepository;

        public HomeController(IPaisRepository iPaisRepository) {

            _IPaisRepository = iPaisRepository;

        }
        public IActionResult Index()
        {
           //throw new ApplicationException("laca");
            var result = _IPaisRepository.GetPaises();
            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
