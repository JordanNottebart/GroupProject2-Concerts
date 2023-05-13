using CENV_JMH.DA;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class AdminShowingsController : Controller
    {
        public ActionResult Index([FromServices] ShowingService service)
        {
            return View(service.GetShowings().ToList());
        }

        public ActionResult Details([FromServices] ShowingService service, int id)
        {
            Showing model = service.GetShowingById(id);             
            return View(model);
        }

        [HttpPost]
        public ActionResult Create([FromServices]ShowingService service, int id, string name, double ticketPrice, string? picture_URL)
        {
            Showing newShow= new Showing();
            newShow.ShowingID = id;
            newShow.Name = name;
            newShow.TicketPrice = ticketPrice;
            newShow.Picture_URL = picture_URL;

            service.CreateShowing(newShow);

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Showing());
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromServices] ShowingService service, int id)
        {

                var model = service.GetShowingById(id);
                await TryUpdateModelAsync(model);
                service.UpdateShowing(model);
                return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit([FromServices] ShowingService service, int id, int wegwerp)
        {
            return View(service.GetShowingById(id));

        }

        [ HttpGet]
        public IActionResult Delete([FromServices] ShowingService service, int id, int wegwerp)
        {
            return View(service.GetShowingById(id));
        }

        [HttpPost]
        public ActionResult Delete([FromServices] ShowingService service, int id)
        {
            service.DeleteShowing(id);

            return RedirectToAction("Index");
        }
    }
}
