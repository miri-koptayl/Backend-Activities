using Backend.CORE.DTO;
using Backend.CORE.entities;
using Backend.CORE.Iservices;
using Microsoft.AspNetCore.Mvc;
using static Backend.CORE.DTO.ActivitiesDTO;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _ActivitiesService;


        public ActivitiesController(IActivitiesService activitiesService)
        {
            _ActivitiesService = activitiesService;
        }

        [HttpGet]
        public ActionResult<List<Activities>> Get()
        {
            var activities = _ActivitiesService.GetActivities();
            if (activities == null)
                return NotFound("No Activities found.");
            return Ok(activities);
        }

        [HttpPost("register")]
        public ActionResult<ActivitiesDTO> Post([FromBody] ActivitiesDTO activities)
        {
            if (activities == null)
                return BadRequest("Activity data cannot be null.");

            try
            {
                var createdActivities = _ActivitiesService.RegisterActivities(
                    activities.AgeGroupId,
                    activities.PointsValue,
                    activities.ContentUrl,
                    activities.Type,
                    activities.Description,
                    activities.Title
                );

                return CreatedAtAction(nameof(Get), new { id = createdActivities.Id }, createdActivities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public ActionResult<ActivitiesDTO> Put(int id, [FromBody] ActivitiesUpdateDTO activities)
        {
            if (activities == null)
                return BadRequest("Activity data cannot be null.");

            var UpdateActivities = _ActivitiesService.UpdateActivities(
                id,
                 activities.AgeGroupId,
                    activities.PointsValue,
                    activities.ContentUrl,
                    activities.Type,
                    activities.Description,
                    activities.Title,
                    activities.IsApproved

            );

            if (UpdateActivities == null)
                return NotFound($"Activity with ID {id} not found.");

            return Ok(UpdateActivities);
        }

        [HttpDelete("{id}")]
        public ActionResult<Activities> Delete(int id)
        {
            var deletedActivities = _ActivitiesService.RemoveActivities(id);
            if (deletedActivities == null)
                return NotFound($"Activity with ID {id} not found.");
            return Ok(deletedActivities);
        }
    }


}
