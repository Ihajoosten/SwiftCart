using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Dto.Address;
using User.Application.Interfaces;

namespace Address.Api.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAppAddressService _addressService;

        public AddressController(IAppAddressService addressService)
        {
            _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAddresses()
        {
            try
            {
                var addresses = await _addressService.GetAllAsync();
                if (addresses == null || !addresses.Any())
                {
                    return NotFound();
                }
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                var address = await _addressService.GetByIdAsync(id);
                if (address == null)
                {
                    return NotFound();
                }

                return Ok(address);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdAddress = await _addressService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetAddressById), new { id = createdAddress.Id }, createdAddress);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] UpdateAddressDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedAddress = await _addressService.UpdateAsync(id, updateDto);
                if (!updatedAddress)
                {
                    return StatusCode(422, "Could Not Update Address - Unprocessable Content");
                }
                return Ok(updatedAddress);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                var deletedAddress = await _addressService.DeleteAsync(id);
                if (!deletedAddress)
                {
                    return StatusCode(422, "Could Not Delete Address - Unprocessable Content");
                }

                return Ok(deletedAddress);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAddressByUserIdAsync(int userId)
        {
            try
            {
                var address = await _addressService.GetByUserIdAsync(userId);
                if (address == null)
                {
                    return NotFound();
                }

                return Ok(address);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
