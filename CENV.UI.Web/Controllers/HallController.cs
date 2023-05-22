using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class HallController : Controller
    {
        public IActionResult Index([FromServices] HallService service)
        {
            var list = service.GetHalls();
            return View(list);
        }
    }
}
