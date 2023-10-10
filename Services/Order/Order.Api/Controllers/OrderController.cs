using Microsoft.AspNetCore.Mvc;
using Order.Application.Dto.Order;
using Order.Application.Interfaces;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IAppOrderService _orderService;

        public OrderController(IAppOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();
                if (orders == null || !orders.Any())
                {
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult?> GetOrder(int orderId)
        {
            try
            {
                var order = await _orderService.GetByIdAsync(orderId);

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
        public async Task<IActionResult?> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdOrder = await _orderService.CreateAsync(createOrderDto);
                return CreatedAtAction(nameof(GetOrder), new { orderId = createdOrder.Id }, createdOrder);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult?> UpdateOrder(int orderId, [FromBody] UpdateOrderDto updateOrderDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedOrder = await _orderService.UpdateAsync(orderId, updateOrderDto);
                if (!updatedOrder)
                {
                    return StatusCode(422, "Could Not Delete Order - Unprocessable Content");
                }

                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult?> DeleteOrder(int orderId)
        {
            try
            {
                var deletedOrder = await _orderService.DeleteAsync(orderId);
                if (!deletedOrder)
                {
                    return StatusCode(422, "Could Not Delete Order - Unprocessable Content");
                }

                return Ok(deletedOrder);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult?> GetOrdersByCustomer(int customerId)
        {
            try
            {
                var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
                if (orders == null || !orders.Any())
                {
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
