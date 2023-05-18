using CENV_JMH.DA;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class AdminShowingInstanceController : Controller
    {
        [HttpGet]
        public IActionResult CreateAsync([FromServices] ShowingInstanceService service, int id)
        {
            ShowingInstance showingInstance = service.GetShowingInstanceById(id);
            return View(showingInstance);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromServices] ShowingInstanceService service, int id, int showingID, int hallID, DateTime date, int seatsSold)
        {

            ShowingInstance showingInstance;
            if (id == 0)
            {
                showingInstance = new ShowingInstance
                {
                    ID = id,
                    ShowingID = showingID,
                    HallID = hallID,
                    Date = date,
                    SeatsSold = seatsSold
                };
                service.CreateShowingInstance(showingInstance);
            }
            else
            {
                showingInstance = service.GetShowingInstanceById(id);
                await TryUpdateModelAsync(showingInstance);
                service.UpdateShowingInstance(showingInstance);
            }
            return RedirectToAction("Create?id=" + id);
        }
    }
}

