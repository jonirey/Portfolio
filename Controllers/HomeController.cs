using Microsoft.AspNetCore.Mvc;
using portfolioMVC.Models;
using System.Diagnostics;

namespace portfolioMVC.Controllers
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

            if (TempData["Error"] != null) { 
            ViewBag.mensaje = TempData["Error"].ToString();
            }
            return View();
            
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}