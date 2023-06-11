using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers.Admin
{
    public class AdminShowingInstanceController : Controller
    {
        private readonly ShowingService _showingService;
        private readonly HallService _hallService;

        public AdminShowingInstanceController(ShowingService showingService, HallService hallService)
        {
            _hallService= hallService;
            _showingService = showingService;
        }

        [HttpGet]
        public IActionResult CreateAsync([FromServices] ShowingInstanceService service, int id)
        {
            ShowingInstance showingInstance = service.GetShowingInstanceById(id);
            ViewBag.Showings = _showingService.GetShowings();
            ViewBag.Halls = _hallService.GetHalls();
            ViewBag.Instances = service.GetShowingInstance();
            showingInstance.Date = DateTime.Now.Date;
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
            return Redirect("/AdminShowingDetail/Index?id=" + showingID);
        }
    }
}