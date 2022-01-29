using Microsoft.AspNetCore.Mvc;
using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> Get() => await _userService.Get();

        /// <summary>
        /// Get users by Id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await _userService.Get(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">JSON representation of a user</param>
        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            await _userService.Create(user);

            return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
        }

        /// <summary>
        /// Edit existing user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="user">JSON representation of a user</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserModel user)
        {
            var existingUser = await _userService.Get(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            await _userService.Update(id, user);

            return NoContent();
        }

        /// <summary>
        /// Delete user by Id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingUser = await _userService.Get(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            await _userService.Remove(id);

            return NoContent();
        }
    }
}
