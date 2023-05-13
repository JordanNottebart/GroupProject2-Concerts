using CENV_JMH.DA;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class AdminHallController : Controller
    {
        public IActionResult Index([FromServices] HallService hallService)
        {
            var hall = hallService.GetHalls().ToList();
            return View(hall);
        }

        public IActionResult Details([FromServices] HallService hallService, int id)
        {
            var hall = hallService.GetHallById(id);
            return View(hall);
        }

        [HttpGet]
        public IActionResult Edit([FromServices] HallService hallService, int id)
        {
            var hall = hallService.GetHallById(id);
            return View(hall);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromServices] HallService hallService, int id, Hall hall)
        {
            var hallEdited = hallService.GetHallById(id);
            await TryUpdateModelAsync(hallEdited);
            hallService.UpdateAndCreateHall(hallEdited);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var hallToCreate = hallService.UpdateAndCreateHall();

            //return View(hallToCreate);
            return View(new Hall());
        }

        [HttpPost]
        public IActionResult Create([FromServices] HallService hallService, int id, string name, int maxNumberOfPlaces)
        {
            Hall newHall = new Hall();

            newHall.HallID = id;
            newHall.Name = name;
            newHall.MaxNumberOfPlaces = maxNumberOfPlaces;
            hallService.UpdateAndCreateHall(newHall);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete([FromServices] HallService hallService, int id)
        {
            var hall = hallService.GetHallById(id);
            return View(hall);
        }

        [HttpPost]
        public IActionResult Delete([FromServices] HallService hallService, int id, Hall hall)
        {
            hallService.DeleteHall(id);
            return RedirectToAction("Index");
        }
    }
}
