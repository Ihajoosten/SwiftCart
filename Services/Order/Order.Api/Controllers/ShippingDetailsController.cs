using Microsoft.AspNetCore.Mvc;
using Order.Application.Dto.ShippingDetails;
using Order.Application.Interfaces;

namespace Order.Api.Controllers
{

    [ApiController]
    [Route("api/shippingdetails")]
    public class ShippingDetailsController : ControllerBase
    {
        private readonly IAppShippingDetailsService _shippingDetailsService;

        public ShippingDetailsController(IAppShippingDetailsService shippingDetailsService)
        {
            _shippingDetailsService = shippingDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            try
            {
                var details = await _shippingDetailsService.GetAllAsync();
                if (details == null || !details.Any())
                {
                    return NotFound();
                }
                return Ok(details);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{shippingDetailsId}")]
        public async Task<IActionResult?> GetOrderItem(int shippingDetailsId)
        {
            try
            {
                var shippingDetails = await _shippingDetailsService.GetByIdAsync(shippingDetailsId);

                if (shippingDetails == null)
                {
                    return NotFound();
                }

                return Ok(shippingDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult?> CreateShippingDetails([FromBody] CreateShippingDetailsDto createShippingDetailsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdShippingDetails = await _shippingDetailsService.CreateAsync(createShippingDetailsDto);
                return CreatedAtAction(nameof(GetShippingDetailsByOrderId), new { orderId = createdShippingDetails.Id }, createdShippingDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{shippingDetailsId}")]
        public async Task<IActionResult?> UpdateShippingDetails(int shippingDetailsId, [FromBody] UpdateShippingDetailsDto updateShippingDetailsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedShippingDetails = await _shippingDetailsService.UpdateAsync(shippingDetailsId, updateShippingDetailsDto);
                if (!updatedShippingDetails)
                {
                    return StatusCode(422, "Could Not Update Shipping Details - Unprocessable Content");
                }

                return Ok(updatedShippingDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{shippingDetailsId}")]
        public async Task<IActionResult?> DeleteShippingDetails(int shippingDetailsId)
        {
            try
            {
                var deletedShippingDetails = await _shippingDetailsService.DeleteAsync(shippingDetailsId);
                if (!deletedShippingDetails)
                {
                    return StatusCode(422, "Could Not Delete Shipping Details - Unprocessable Content");
                }

                return Ok(deletedShippingDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult?> GetShippingDetailsByOrderId(int orderId)
        {
            try
            {
                var shippingDetails = await _shippingDetailsService.GetShippingDetailsByOrderIdAsync(orderId);
                if (shippingDetails == null)
                {
                    return NotFound();
                }
                return Ok(shippingDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
