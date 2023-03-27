using CENV.UI.Web.Models;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CENV.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] ShowingService showingService)
        {
            var x = showingService.GetHomeShowings(6);
            return View(x);
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