using Auth.Application.Dto.Token;
using Auth.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenController : ControllerBase
    {
        private readonly IAppTokenService _tokenService;

        public TokenController(IAppTokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var tokenResponse = await _tokenService.RefreshAccessTokenAsync(refreshTokenDto);

                if (tokenResponse == null)
                {
                    // Token refresh failed
                    return Unauthorized("Invalid refresh token.");
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
