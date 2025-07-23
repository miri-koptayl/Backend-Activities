using Backend.CORE.DTO;
using Backend.CORE.entities;
using Backend.CORE.Entities;
using Backend.CORE.Iservices;
using Backend.SERVER;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAchievementsController:ControllerBase
    {
        private readonly IUserAchievementsService _userAchievementsService;

        public UserAchievementsController(IUserAchievementsService userAchievementsService)
        {
            _userAchievementsService = userAchievementsService;
        }

        [HttpGet]
        public ActionResult<List<UserAchievement>> Get()
        {
            var userAchievement = _userAchievementsService.GetAllUserAchievement();
            if (userAchievement == null)
                return NotFound("No userAchievement found.");
            return Ok(userAchievement);
        }
     

        [HttpPost("register")]
        public ActionResult<UserAchievementsDTO> Post([FromBody] UserAchievementsDTO userAchievements)
        {
            if (userAchievements == null)
                return BadRequest("userAchievements data cannot be null.");

            try
            {
                var createdUserAchievement = _userAchievementsService.CreateUserAchievement(
                    userAchievements.UserId,
                    userAchievements.AchievementId,
                    userAchievements.ActivityId??0,
                    userAchievements.Notes,
                    userAchievements.EarnedDate
                );

                return CreatedAtAction(nameof(Get), new { id = createdUserAchievement.Id }, createdUserAchievement);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPut("{id}")]
        public ActionResult<UserAchievementsDTO> Put(int id, [FromBody] UserAchievementsDTO UserAchievements)
        {
            if (UserAchievements == null)
                return BadRequest("UserAchievements data cannot be null.");

            var updatedUserAchievements = _userAchievementsService.UpdateAchievementsUser(
                UserAchievements.UserId,
                    UserAchievements.AchievementId,
                    UserAchievements.ActivityId??0,
                    UserAchievements.Notes,
                    UserAchievements.EarnedDate
            );

            if (updatedUserAchievements == null)
                return NotFound($"UserAchievements with ID {id} not found.");

            return Ok(updatedUserAchievements);
        }
        [HttpGet("by-user/{userId}")]
        public ActionResult<List<Achievements>> GetAchievementsByUserId(int userId)
        {
            var achievements = _userAchievementsService.GetAchievementsByUserId(userId);
            if (achievements == null || achievements.Count == 0)
                return NotFound($"No achievements found for user with ID {userId}.");
            return Ok(achievements);
        }

        [HttpDelete("{id}")]
        public ActionResult<UserAchievement> Delete(int id)
        {
            var deletedUserAchievement = _userAchievementsService.RemoveUserAchievement(id);
            if (deletedUserAchievement == null)
                return NotFound($"UserAchievement with ID {id} not found.");
            return Ok(deletedUserAchievement);
        }
    }
}
