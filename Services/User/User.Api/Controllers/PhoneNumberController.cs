using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Dto.PhoneNumber;
using User.Application.Interfaces;

namespace User.Api.Controllers
{
    [ApiController]
    [Route("api/phone-numbers")]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IAppPhoneNumberService _appPhoneNumberService;

        public PhoneNumberController(IAppPhoneNumberService appPhoneNumberService)
        {
            _appPhoneNumberService = appPhoneNumberService ?? throw new ArgumentNullException(nameof(appPhoneNumberService));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllPhoneNumbers()
        {
            try
            {
                var PhoneNumberes = await _appPhoneNumberService.GetAllAsync();
                if (PhoneNumberes == null || !PhoneNumberes.Any())
                {
                    return NotFound();
                }
                return Ok(PhoneNumberes);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneNumberById(int id)
        {
            try
            {
                var PhoneNumber = await _appPhoneNumberService.GetByIdAsync(id);
                if (PhoneNumber == null)
                {
                    return NotFound();
                }

                return Ok(PhoneNumber);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoneNumber([FromBody] CreatePhoneNumberDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdPhoneNumber = await _appPhoneNumberService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetPhoneNumberById), new { id = createdPhoneNumber.Id }, createdPhoneNumber);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhoneNumber(int id, [FromBody] UpdatePhoneNumberDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedPhoneNumber = await _appPhoneNumberService.UpdateAsync(id, updateDto);
                if (!updatedPhoneNumber)
                {
                    return StatusCode(422, "Could Not Update Phone Number - Unprocessable Content");
                }
                return Ok(updatedPhoneNumber);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumber(int id)
        {
            try
            {
                var deletedPhoneNumber = await _appPhoneNumberService.DeleteAsync(id);
                if (!deletedPhoneNumber)
                {
                    return StatusCode(422, "Could Not Delete Phone Number - Unprocessable Content");
                }

                return Ok(deletedPhoneNumber);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPhoneNumberByUserIdAsync(int userId)
        {
            try
            {
                var PhoneNumbers = await _appPhoneNumberService.GetByUserIdAsync(userId);
                if (PhoneNumbers == null || !PhoneNumbers.Any())
                {
                    return NotFound();
                }

                return Ok(PhoneNumbers);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
