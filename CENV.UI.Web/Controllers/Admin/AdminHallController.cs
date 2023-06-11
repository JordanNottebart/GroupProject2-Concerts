using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers.Admin
{
    #region Hall Controller
    /// <summary>
    /// The TicketService class provides methods to retrieve and manipulate ticket data. (CRUD)
    /// </summary> 
    #endregion

    public class AdminHallController : Controller
    {
        public IActionResult Index([FromServices] HallService hallService)
        {
            var hall = hallService.GetHalls().ToList();
            return View(hall);
        }

        [HttpGet]
        public IActionResult Edit([FromServices] HallService hallService, int id)
        {
            var hall = hallService.GetHallById(id);
            return View(hall);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromServices] HallService hallService, int id, Hall hall, int maxNumberOfPlaces)
        {
            // Check if the number is negative or zero
            if (maxNumberOfPlaces <= 0)
            {
                ModelState.AddModelError("MaxNumberOfPlaces", "Maximum number of places must be a positive integer greater than zero.");
                // You can handle the error by returning a view with the validation errors
                return View();
            }

            var hallEdited = hallService.GetHallById(id);
            await TryUpdateModelAsync(hallEdited);
            hallService.UpdateHall(id, hallEdited);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Hall());
        }

        [HttpPost]
        public IActionResult Create([FromServices] HallService hallService, int id, string name, int maxNumberOfPlaces)
        {
            // Check if the number is negative or zero
            if (maxNumberOfPlaces <= 0)
            {
                ModelState.AddModelError("MaxNumberOfPlaces", "Maximum number of places must be a positive integer greater than zero.");
                // You can handle the error by returning a view with the validation errors
                return View();
            }

            Hall newHall = new Hall();

            newHall.HallID = id;
            newHall.Name = name;
            newHall.MaxNumberOfPlaces = maxNumberOfPlaces;
            hallService.CreateHall(newHall);

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
