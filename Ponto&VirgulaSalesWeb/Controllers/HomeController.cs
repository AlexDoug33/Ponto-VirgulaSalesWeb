using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ponto_VirgulaSalesWeb.Models;
using Ponto_VirgulaSalesWeb.Models.ViewModels;

namespace Ponto_VirgulaSalesWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Salles Web App";
            ViewData["Adm"] = "Ponto & Vírgula";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
