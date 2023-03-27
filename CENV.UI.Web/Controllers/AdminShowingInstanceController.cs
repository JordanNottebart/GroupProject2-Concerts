using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.AspNetCore.Mvc;

namespace CENV.UI.Web.Controllers
{
    public class AdminShowingInstanceController : Controller
    {
        public IActionResult Create(int id, int showingID, int hallID, DateTime date, int seatsSold)
        {

            ShowingInstance showingInstance;
            using (var repo = new Repository())
            {
                showingInstance = new ShowingInstance();
                showingInstance.ID = id;
                showingInstance.ShowingID = showingID;
                showingInstance.HallID = hallID;
                showingInstance.Date = date;
                showingInstance.SeatsSold = seatsSold;
            }
            return View(showingInstance);

        }
    }
}
