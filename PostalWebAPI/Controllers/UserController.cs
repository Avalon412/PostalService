using Microsoft.AspNetCore.Mvc;
using PostalWebAPI.Contracts;
using PostalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> Get() => await _userService.Get();

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

        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            await _userService.Create(user);

            return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
        }

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
