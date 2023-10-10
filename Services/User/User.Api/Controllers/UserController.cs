using Microsoft.AspNetCore.Mvc;
using User.Application.Dto.User;
using User.Application.Interfaces;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                if (users == null || !users.Any())
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult?> GetUser(int userId)
        {
            try
            {
                var user = await _userService.GetByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        /*[HttpPost]
        public async Task<IActionResult?> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdUser = await _userService.CreateAsync(createUserDto);
                return CreatedAtAction(nameof(GetUser), new { userId = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }*/

        [HttpPut("{userId}")]
        public async Task<IActionResult?> UpdateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedUser = await _userService.UpdateAsync(userId, updateUserDto);
                if (!updatedUser)
                {
                    return StatusCode(422, "Could Not Update User - Unprocessable Content");
                }

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult?> DeleteUser(int userId)
        {
            try
            {
                var deletedUser = await _userService.DeleteAsync(userId);
                if (!deletedUser)
                {
                    return StatusCode(422, "Could Not Delete User - Unprocessable Content");
                }

                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult?> GetUserByUsername(string username)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(username);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult?> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
