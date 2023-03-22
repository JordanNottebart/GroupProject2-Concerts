using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class ShowingController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }

    }
}
