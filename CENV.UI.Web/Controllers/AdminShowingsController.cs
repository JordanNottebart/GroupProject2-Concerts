using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class AdminShowingsController : Controller
    {
        public ActionResult Index()
        {
            using (var repo = new Repository())
            {
                return View(repo.Showings.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            Showing model;
            using (var repo = new Repository())
            {
                model = repo.Showings.FirstOrDefault(s => s.ShowingID == id);
            }
            return View(model);
        }

        public ActionResult Create(int id, string name, double ticketPrice, string? picture_URL)
        {
            Showing newShow;
            using (var repo = new Repository())
            {
                newShow = new Showing();
                newShow.ShowingID = id;
                newShow.Name = name;
                newShow.TicketPrice = ticketPrice;
                newShow.Picture_URL = picture_URL;
                repo.Add(newShow);

            }

            return View(newShow);
        }

        public async Task<ActionResult> Edit(int id)
        {
            using (var repo = new Repository())
            {
                var model = repo.Showings.FirstOrDefault(s => s.ShowingID == id);
                await TryUpdateModelAsync(model);
                repo.SaveChanges();
                return View(model);
            }

        }

        public ActionResult Delete(int id)
        {
            using (var repo = new Repository())
            {
                var model = repo.Showings.FirstOrDefault(s => s.ShowingID == id);
                repo.Showings.Remove(model);
                repo.SaveChanges();
            }

            return View();
        }
    }
}
