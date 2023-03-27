using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class AdminHallController : Controller
    {
        public IActionResult Index()
        {
            using (var repo = new Repository())
            {
                return View(repo.Halls.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            Hall model;
            using (var repo = new Repository())
            {
                model = repo.Halls.FirstOrDefault(h => h.HallID == id);
            }

            return View(model);
        }

        public ActionResult Create(int id, string name, int maxNumberOfPlaces)
        {
            Hall newHall;
            using (var repo = new Repository())
            {
                newHall = new Hall();
                newHall.HallID = id;
                newHall.Name = name;
                newHall.MaxNumberOfPlaces = maxNumberOfPlaces;
                repo.Add(newHall);

            }

            return View(newHall);
        }

        public async Task<ActionResult> Edit(int id)
        {
            using (var repo = new Repository())
            {
                var model = repo.Halls.FirstOrDefault(h => h.HallID == id);
                await TryUpdateModelAsync(model);
                repo.SaveChanges();
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var repo = new Repository())
            {
                var model = repo.Halls.FirstOrDefault(h => h.HallID == id);
                repo.Halls.Remove(model);
                repo.SaveChanges();
            }

            return View();
        }
    }
}
