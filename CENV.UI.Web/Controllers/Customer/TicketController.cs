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
            var current = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var x = _TicketService.GetTicket(current);
            return View(x);
        }

        [HttpGet]
        public IActionResult BuyTickets(int id)
        {
            var x = _ShowingInstanceService.GetShowingInstanceById(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult BuyTickets(int id, ShowingInstance showingInstance)
        {
            var seats = _ShowingInstanceService.GetShowingInstanceById(id);

            if (seats.SeatsSold < seats.Hall.MaxNumberOfPlaces)
            {
                var current = User.FindFirstValue(ClaimTypes.NameIdentifier);
                seats.SeatsSold++;
                var ticket = new Ticket()
                {
                    //ShowingInstance = x,
                    userId = current,
                    showingInstanceId = seats.ID

                };
                _TicketService.Create(ticket);
            }
            else
            {
                return RedirectToAction("Index");
            }
            _ShowingInstanceService.UpdateShowingInstance(seats);
            return RedirectToAction("Index");
        }
    }
}
