using CENV_JMH.API.Dto;
using CENV_JMH.DO;
using CENV_JMH.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CENV_JMH.API.Controllers
{
    #region API ShowingInstancesController
    /// <summary>
    /// This controller provides a RESTful API for managing showing instances, including retrieving
    /// showing instances information from database, creating new showing instances, updating
    /// existing showing instances and deleting showing instances.
    /// </summary>
    ///
    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class ShowingInstancesController : ControllerBase
    {
        private readonly ShowingInstanceService _showingInstanceService;

        public ShowingInstancesController(ShowingInstanceService showingInstanceService)
        {
            _showingInstanceService = showingInstanceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var showingInstances = _showingInstanceService.GetShowingInstance();
                return Ok(showingInstances);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var showingInstance = _showingInstanceService.GetShowingInstanceById(id);

                if (showingInstance == null)
                {
                    return NotFound("Showing instance not found");
                }

                return Ok(showingInstance);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }

        [HttpGet("byid")]
        public IActionResult GetByIdQueryParam(int showingInstanceId, string? personalMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(personalMessage))
                {
                    personalMessage = "This is your personal message";
                }

                var showingInstance = _showingInstanceService.GetShowingInstanceById(showingInstanceId);

                if (showingInstance == null)
                {
                    return NotFound("Showing instance not found");
                }

                return Ok(new { showingInstance, personalMessage });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] ShowingInstanceDto showingInstance)
        {
            try
            {
                var createdShowingInstance = _showingInstanceService.CreateAndReturnNewShowingInstance(new ShowingInstance
                {
                    ShowingID = showingInstance.ShowingID,
                    HallID = showingInstance.HallID,
                    Date = showingInstance.Date
                });

                return CreatedAtAction("GetById", new { id = createdShowingInstance.ID }, createdShowingInstance);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }

        [HttpPatch("StartTime/{id}")]
        public IActionResult UpdateStartTime(int id, [FromBody] UpdateStartTimeDto updateStartTimeDto)
        {
            try
            {
                var showingInstance = _showingInstanceService.UpdateStartTime(id, updateStartTimeDto.StartTime);

                if (showingInstance == null)
                {
                    return NotFound("Showing instance not found");
                }

                return Ok(new { Message = "Showing instance updated", showingInstance });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] ShowingInstanceDto showingInstance)
        {
            try
            {
                var updatedShowingInstance = _showingInstanceService.UpdateAndReturnShowingInstance(id, new ShowingInstance
                {
                    ShowingID = showingInstance.ShowingID,
                    HallID = showingInstance.HallID,
                    Date = showingInstance.Date
                });

                if (updatedShowingInstance == null)
                {
                    return NotFound("Showing instance not found");
                }

                return CreatedAtAction("GetById", new { id = updatedShowingInstance.ID }, updatedShowingInstance);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _showingInstanceService.DeleteAndReturnBoolShowingInstance(id);

                if (isDeleted)
                {
                    return Ok(new { Message = "Showing instance deleted successfully" });
                }

                return BadRequest(new { Message = "Something went wrong trying to delete showing instance." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. Please try again." });
            }
        }
    }
}
