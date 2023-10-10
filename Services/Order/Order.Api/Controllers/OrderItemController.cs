using Microsoft.AspNetCore.Mvc;
using Order.Application.Dto.OrderItem;
using Order.Application.Interfaces;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("api/orderitems")]
    public class OrderItemController : ControllerBase
    {
        private readonly IAppOrderItemService _orderItemService;

        public OrderItemController(IAppOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            try
            {
                var items = await _orderItemService.GetAllAsync();
                if (items == null || !items.Any())
                {
                    return NotFound();
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{orderItemId}")]
        public async Task<IActionResult?> GetOrderItem(int orderItemId)
        {
            try
            {
                var orderItem = await _orderItemService.GetByIdAsync(orderItemId);

                if (orderItem == null)
                {
                    return NotFound();
                }

                return Ok(orderItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult?> CreateOrderItem([FromBody] CreateOrderItemDto createOrderItemDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdOrderItem = await _orderItemService.CreateAsync(createOrderItemDto);
                return CreatedAtAction(nameof(GetOrderItemsByOrderId), new { orderId = createdOrderItem.Id }, createdOrderItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{orderItemId}")]
        public async Task<IActionResult?> UpdateOrderItem(int orderItemId, [FromBody] UpdateOrderItemDto updateOrderItemDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedOrderItem = await _orderItemService.UpdateAsync(orderItemId, updateOrderItemDto);
                if (!updatedOrderItem)
                {
                    return StatusCode(422, "Could Not Update Order Item - Unprocessable Content");
                }

                return Ok(updatedOrderItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult?> DeleteOrderItem(int orderItemId)
        {
            try
            {
                var deletedOrderItem = await _orderItemService.DeleteAsync(orderItemId);
                if (!deletedOrderItem)
                {
                    return StatusCode(422, "Could Not Delete Order Item - Unprocessable Content");
                }

                return Ok(deletedOrderItem);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult?> GetOrderItemsByOrderId(int orderId)
        {
            try
            {
                var orderItems = await _orderItemService.GetOrderItemsByOrderIdAsync(orderId);
                if (orderItems == null || !orderItems.Any())
                {
                    return NotFound();
                }
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("topselling/{count}")]
        public async Task<IActionResult?> GetTopSellingOrderItems(int count)
        {
            try
            {
                var topSellingItems = await _orderItemService.GetTopSellingOrderItemsAsync(count);
                if (topSellingItems == null)
                {
                    return NotFound();
                }
                return Ok(topSellingItems);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
