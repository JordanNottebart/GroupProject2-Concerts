using CENV_JMH.API.Dto;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CENV_JMH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingsController : ControllerBase
    {
        private readonly ShowingService _showService;
        public ShowingsController(ShowingService showService)
        {
            this._showService = showService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listOfShows = _showService.GetShowings();
                return Ok(listOfShows);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var show = _showService.GetShowingById(id);

                if (show == null)
                {
                    return NotFound("Show not found");
                }

                return Ok(show);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int showId, string? personalMessage)
        {

            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var show = _showService.GetShowingById(showId);

                if (show == null)
                {
                    //404 not found
                    return NotFound("Show not found");
                }
                return Ok(new { show, personalMessage });
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ShowingDto show)
        {

            try
            {
                var createdShow = _showService.CreateShowing(new Showing
                {
                    Name = show.Name,
                    TicketPrice = show.TicketPrice,
                    Picture_URL = show.Picture_URL,
                });
                return CreatedAtAction("GetById", new { id = createdShow.ShowingID }, createdShow);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }

        }


        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] ShowingDto show)
        {

            try
            {
                var showToUpdate = _showService.UpdateShowing(id, new Showing
                {
                    Name = show.Name,
                    TicketPrice = show.TicketPrice,
                    Picture_URL = show.Picture_URL,
                });

                if (showToUpdate == null)
                {
                    return NotFound("Show not found");
                }

                return CreatedAtAction("GetById", new { id = showToUpdate.ShowingID }, showToUpdate);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _showService.DeleteShowing(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Show deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete show." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
