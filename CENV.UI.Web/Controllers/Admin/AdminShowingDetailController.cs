using CENV.UI.Web.Models;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers.Admin
{
    public class AdminShowingDetailController : Controller
    {
        public IActionResult Index([FromServices] ShowingInstanceService instanceservice, [FromServices] ShowingService showingService, int id)
        {
            var showing = showingService.GetShowingById(id);
            var listOfInstances = instanceservice.GetShowingInstancesByShowID(id);

            var model = new ShowDetailModel() { TheInstances = listOfInstances, TheShow = showing };
            return View(model);
        }
    }
}
