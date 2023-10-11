using Auth.Application.Dto.Auth;
using Auth.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegistrationController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public RegistrationController(IAppUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if the username or email is already taken
                if (await _userService.GetUserByUsernameAsync(registerDto.Username) != null ||
                    await _userService.GetUserByEmailAsync(registerDto.Email) != null)
                {
                    return Conflict("Username or email is already taken.");
                }

                // Register the user
                var createdUser = await _userService.RegisterUserAsync(registerDto);

                if (createdUser)
                {
                    var result = CreatedAtAction(nameof(LoginController.Login), "Login", new { username = registerDto.Username, password = registerDto.Password });
                    return Ok(result);
                }
                return StatusCode(422, "Unprocessable Entity - Failed to register User");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
