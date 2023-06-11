using CENV_JMH.API.Dto;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Mvc;

namespace CENV_JMH.API.Controllers
{
    #region API HallController
    /// <summary>
    /// This controller provides a RESTful API for managing halls, including retrieving hall
    /// information from database, creating new halls, updating existing halls and deleting halls.
    /// </summary>
    ///
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly HallService _hallService;
        public HallsController(HallService hallService)
        {
            this._hallService = hallService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listHalls = _hallService.GetHalls();
                return Ok(listHalls);
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
                var hall = _hallService.GetHallById(id);

                if (hall == null)
                {
                    return NotFound("Hall not found");
                }

                return Ok(hall);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int hallId, string? personalMessage)
        {

            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var hall = _hallService.GetHallById(hallId);

                if (hall == null)
                {
                    //404 not found
                    return NotFound("Hall not found");
                }
                return Ok(new { hall, personalMessage });
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HallDto hall)
        {

            try
            {
                var createdHall = _hallService.CreateHall(new Hall
                {
                    Name = hall.Name,
                    MaxNumberOfPlaces = hall.MaxNumberOfPlaces,
                    
                });
                return CreatedAtAction("GetById", new { id = createdHall.HallID }, createdHall);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }

        }

        [HttpPatch("MaxNumberOfPlaces/{id}")]
        public IActionResult UpdateMaxNumberOfPlaces(int id, [FromBody] UpdateMaxNumberOfPlacesDto udd)
        {

            try
            {
                var hall = _hallService.UpdateMaxNumberOfPlaces(id, udd.MaxNumberOfPlaces);

                if (hall == null) 
                {
                    return NotFound("Hall not found");
                }

                return Ok(new { Message = "Hall Updated", hall });
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }

        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] HallDto hall)
        {

            try
            {
                var hallToUpdate = _hallService.UpdateHall(id, new Hall
                {
                    Name = hall.Name,
                    MaxNumberOfPlaces = hall.MaxNumberOfPlaces,
                });

                if (hallToUpdate == null)
                {
                    return NotFound("Hall not found");
                }

                return CreatedAtAction("GetById", new { id = hallToUpdate.HallID }, hallToUpdate);
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
                var isDeleted = _hallService.DeleteHall(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Hall deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete hall." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (new { Message = "Something went wrong please try again" }));
            }
        }
    }
}
