using CENV_JMH.DA;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers.Admin
{
    public class AdminShowingInstanceController : Controller
    {
        [HttpGet]
        public IActionResult Create([FromServices] ShowingService showingService, [FromServices] HallService hallService, int id)
        {
            Showing showing = showingService.GetShowingById(id);
            Hall hall = hallService.GetHallById(showing.ShowingID);

            ShowingInstance showingInstance = new ShowingInstance
            {
                ShowingID = showing.ShowingID,
                HallID = hall.HallID
            };

            return View(showingInstance);
        }

        [HttpPost]
        public IActionResult Create([FromServices] ShowingInstanceService service, ShowingInstance showingInstance)
        {
            if (ModelState.IsValid)
            {
                service.CreateShowingInstance(showingInstance);
                return RedirectToAction("Index");
            }

            return View(showingInstance);
        }

    }
}