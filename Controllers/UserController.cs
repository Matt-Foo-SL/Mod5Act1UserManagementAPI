using Microsoft.AspNetCore.Mvc;
using Mod5Act1UserManagementAPI.Models;
using Mod5Act1UserManagementAPI.Data;

namespace Mod5Act1UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // GET: api/user
        [HttpGet]
        public ActionResult GetAllUsers() => Ok(UserRepository.GetAll());

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
		{
			try
			{
				var user = UserRepository.GetById(id);
				return user == null ? NotFound() : Ok(user);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while retrieving the user.", details = ex.Message });
			}
        }

        // POST: api/user
        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);
				var created = UserRepository.Add(user);
				return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while retrieving the user.", details = ex.Message });
			}
			
			 
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User user)
		{
			try
			{
 				if (!ModelState.IsValid)
        		return BadRequest(ModelState);
				var existingUser = UserRepository.GetById(id);
			    if (existingUser == null)
			    {
			        return NotFound(new { message = $"User with ID {id} not found." });
			    }
	    		var success = UserRepository.Update(id, user);
	    		return Ok("User updated successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while retrieving the user.", details = ex.Message });
			}
			
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
			try
			{
				var existingUser = UserRepository.GetById(id);
				if (existingUser == null)
				{
					return NotFound(new { message = $"User with ID {id} not found." });
				}

				var success = UserRepository.Delete(id);
				return  Ok("User deleted successfully.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred while retrieving the user.", details = ex.Message });
			}
        }
    }
}
