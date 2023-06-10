using CENV_JMH.API.Dto;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CENV_JMH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _ticketService;
        public TicketsController(TicketService ticketService)
        {
            this._ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var user = User.Identity;
                var listTickets = _ticketService.GetTicket(user.Name);
                return Ok(listTickets);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
