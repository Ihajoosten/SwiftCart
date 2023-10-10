using Microsoft.AspNetCore.Mvc;
using User.Application.Dto;
using User.Application.Dto.User;
using User.Application.Interfaces;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authService;
        private readonly IUserAppService _userAppService;

        public AuthController(IAuthAppService authService, IUserAppService userAppService)
        {
            _authService = authService;
            _userAppService = userAppService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var token = await _authService.AuthenticateUserAsync(loginDto.Username, loginDto.Password);
                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdUser = await _userAppService.CreateAsync(createUserDto);
                if (createdUser == null)
                {
                    return BadRequest("User registration failed");
                }

                return CreatedAtAction(nameof(Login), new { username = createdUser.Username, password = createUserDto.Password }, createdUser);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
