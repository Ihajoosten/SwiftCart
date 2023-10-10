using Microsoft.AspNetCore.Mvc;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Interfaces;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("api/orderstatushistory")]
    public class OrderStatusHistoryController : ControllerBase
    {
        private readonly IAppOrderStatusHistoryService _orderStatusHistoryService;

        public OrderStatusHistoryController(IAppOrderStatusHistoryService orderStatusHistoryService)
        {
            _orderStatusHistoryService = orderStatusHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderStatusHistories()
        {
            try
            {
                var ordersStats = await _orderStatusHistoryService.GetAllAsync();
                if (ordersStats == null || !ordersStats.Any())
                {
                    return NotFound();
                }
                return Ok(ordersStats);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{statusHistoryId}")]
        public async Task<IActionResult?> GetOrderStatusHistory(int statusHistoryId)
        {
            try
            {
                var order = await _orderStatusHistoryService.GetByIdAsync(statusHistoryId);

                if (order == null)
                {
                    return NotFound();
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult?> CreateOrderStatusHistory([FromBody] CreateOrderStatusHistoryDto createOrderStatusHistoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdStatusHistory = await _orderStatusHistoryService.CreateAsync(createOrderStatusHistoryDto);
                return CreatedAtAction(nameof(GetOrderStatusHistoryByOrderId), new { orderId = createdStatusHistory.Id }, createdStatusHistory);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{statusHistoryId}")]
        public async Task<IActionResult?> UpdateOrderStatusHistory(int statusHistoryId, [FromBody] UpdateOrderStatusHistoryDto updateOrderStatusHistoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedStatusHistory = await _orderStatusHistoryService.UpdateAsync(statusHistoryId, updateOrderStatusHistoryDto);
                if (!updatedStatusHistory)
                {
                    return StatusCode(422, "Could Not Update Order Status History - Unprocessable Content");
                }

                return Ok(updatedStatusHistory);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{statusHistoryId}")]
        public async Task<IActionResult?> DeleteOrderStatusHistory(int statusHistoryId)
        {
            try
            {
                var deletedStatusHistory = await _orderStatusHistoryService.DeleteAsync(statusHistoryId);
                if (!deletedStatusHistory)
                {
                    return StatusCode(422, "Could Not Delete Order Status History - Unprocessable Content");
                }

                return Ok(deletedStatusHistory);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult?> GetOrderStatusHistoryByOrderId(int orderId)
        {
            try
            {
                var statusHistory = await _orderStatusHistoryService.GetStatusHistoryByOrderIdAsync(orderId);
                if (statusHistory == null)
                {
                    return NotFound();
                }
                return Ok(statusHistory);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("latest/{orderId}")]
        public async Task<IActionResult?> GetLatestStatusByOrderId(int orderId)
        {
            try
            {
                var latestStatus = await _orderStatusHistoryService.GetLatestStatusByOrderIdAsync(orderId);
                if (latestStatus == null)
                {
                    return NotFound();
                }
                return Ok(latestStatus);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
