using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.Services;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DeliveryEmployee : ControllerBase
    {
        private readonly OrderService _orderService;

        public DeliveryEmployee(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut("assign-delivery")]
        public async Task<IActionResult> AssignOrderToDelivery(int deliveryId, int orderId)
        {
            await _orderService.AssignOrderToDelivery(deliveryId, orderId);



            return Ok(new { message = "Order assigned to delivery successfully." });
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId)
        {
            await _orderService.UpdateOrderStatus(orderId);
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(new ApiResponse<string>(
                   statusCode: 200,
                     message: "Order status updated successfully.",
                        data: order.orderStatus.ToString()
                ));
        }
    }



}

