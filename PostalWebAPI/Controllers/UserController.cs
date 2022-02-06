using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using PostalWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostalWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserDTO>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var users = await _userService.Get();

            var usersDto = _mapper.Map<List<UserModel>, List<UserDTO>>(users);

            return usersDto;
        }

        /// <summary>
        /// Get users by Id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _userService.Get(id);

            if (user is null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDTO>(user);

            return userDto;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">JSON representation of a user</param>
        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
