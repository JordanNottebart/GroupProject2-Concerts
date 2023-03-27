using CENV.UI.Web.Models;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class ShowingDetailController : Controller
    {
        public IActionResult Index([FromServices] ShowingInstanceService instanceservice, [FromServices] ShowingService showingService, int id)
        {
            var showing = showingService.GetShowingById(id);
            var lijstofinstances = instanceservice.GetShowingInstancesByShowID(id);

            var model = new ShowDetailModel() { TheInstances = lijstofinstances , TheShow = showing};
            return View(model);
        }
    }
}
