using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CENV.UI.Web.Controllers.Customer
{
    [Authorize]
    public class TicketController : Controller
    {

        private TicketService _TicketService;
        private ShowingInstanceService _ShowingInstanceService;
        public TicketController([FromServices] TicketService service, [FromServices] ShowingInstanceService siservice)
        {
            _TicketService = service;
            _ShowingInstanceService = siservice;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var curr = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var x = _TicketService.GetTicket(curr);
            return View(x);
        }


        [HttpGet]
        public IActionResult BuyTickets(int id)
        {
            var x = _ShowingInstanceService.GetShowingInstanceById(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult BuyTickets(int id, string blablazever)
        {
            var x = _ShowingInstanceService.GetShowingInstanceById(id);

            if (x.SeatsSold < x.Hall.MaxNumberOfPlaces)
            {
                var curr = User.FindFirstValue(ClaimTypes.NameIdentifier);
                x.SeatsSold++;
                var ticket = new Ticket()
                {
                    //ShowingInstance = x,
                    userId = curr,
                    showingInstanceId = x.ID

                };
                _TicketService.Create(ticket);

            }
            else
            {
                return RedirectToAction("Index");
            }
            _ShowingInstanceService.UpdateShowingInstance(x);
            return RedirectToAction("Index");
        }
    }
}
