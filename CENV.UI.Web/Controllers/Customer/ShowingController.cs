using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers.Customer
{
    public class ShowingController : Controller
    {
        public IActionResult Index([FromServices] ShowingService service)
        {
            var list = service.GetShowings();
            return View(list);
        }

    }
}
