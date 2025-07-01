using Backend.CORE.DTO;       
using Backend.CORE.entities;
using Backend.CORE.Iservices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            var users = _userService.GetUsers();
            if (users == null ) 
                return NotFound("No users found.");
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound($"User with ID {id} not found.");
            return Ok(user);
        }

        [HttpPost("register")]
        public ActionResult<UsersDTO> Post([FromBody] UsersDTO user)
        {
            if (user == null)
                return BadRequest("User data cannot be null.");

            try
            {
                var createdUser = _userService.RegisterUser(
                    user.Username,
                    user.Email,
                    user.Password,
                    user.Age
                );
                return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<UsersDTO> Put(int id,[FromBody] UsersDTO user)
        {
            if (user == null)
                return BadRequest("User data cannot be null.");

            var updatedUser = _userService.UpdateUser(id, user.Username, user.Email, user.Password, user.Age);
            if (updatedUser == null)
                return NotFound($"User with ID {id} not found.");
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public ActionResult<Users> Delete(int id)
        {
            var deletedUser = _userService.RemoveUser(id);
            if (deletedUser == null)
                return NotFound($"User with ID {id} not found.");
            return Ok(deletedUser);
        }
    }
}
