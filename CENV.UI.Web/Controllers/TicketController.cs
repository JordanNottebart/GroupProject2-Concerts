using CENV_JMH.DO;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class BuyTicketController : Controller
    {
        public IActionResult Index()
        {
            var ticket = new Ticket()
            {
                Name = "Test"
            };
            return View(ticket);
        }
    }
}
