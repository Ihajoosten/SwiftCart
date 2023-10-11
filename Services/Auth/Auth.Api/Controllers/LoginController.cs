using Auth.Application.Dto.Auth;
using Auth.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IAppTokenService _tokenService;
        private readonly IAppUserService _userService;

        public LoginController(IAppTokenService tokenService, IAppUserService userService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var tokenResponse = await _tokenService.GenerateTokensAsync(loginDto);

                if (tokenResponse == null)
                {
                    // Authentication failed
                    return Unauthorized("Invalid username or password.");
                }

                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
