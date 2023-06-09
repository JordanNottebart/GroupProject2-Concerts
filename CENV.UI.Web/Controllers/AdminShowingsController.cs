using CENV_JMH.DA;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CENV.UI.Web.Controllers
{
    public class AdminShowingsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminShowingsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public ActionResult Index([FromServices] ShowingService service)
        {
            
            return View(service.GetShowings().ToList());
        }

        public ActionResult Details([FromServices] ShowingService service, int id)
        {
            Showing model = service.GetShowingById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Showing());
        }


        [HttpPost]
        public ActionResult Create([FromServices] ShowingService service, int id, string name, double ticketPrice, string? picture_URL)
        {
            Showing newShow = new Showing();
            newShow.ShowingID = id;
            newShow.Name = name;
            newShow.TicketPrice = ticketPrice;
            newShow.Picture_URL = picture_URL;

            service.CreateShowing(newShow);

            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromServices] ShowingService service, int id, Showing show)
        {
            return View(service.GetShowingById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromServices] ShowingService service, int id)
        {

            var model = service.GetShowingById(id);
            await TryUpdateModelAsync(model);
            service.UpdateShowing(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromServices] ShowingService service, int id, Showing show)
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
