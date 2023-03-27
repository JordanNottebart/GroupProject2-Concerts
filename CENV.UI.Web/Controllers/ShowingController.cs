using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class ShowingController : Controller
    {
        public IActionResult Index([FromServices] ShowingService service)
        {
            var lijst = service.GetShowings();
            return View(lijst);
        }

    }
}
