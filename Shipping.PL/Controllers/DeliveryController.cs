using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Delivery;
using Shipping.BL.Services;
using Shipping.DAL.Entities;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        DeliveryService deliveryService;
        public DeliveryController(DeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        [HttpPost]
        public async Task<ActionResult> AddDelivery(AddDeliveryDTO delivery)
        {

            if (delivery == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var result=  await deliveryService.AddAsync(delivery);
            if (!result.Success)
            {
                return BadRequest(new
                {
                    error = "Failed to create employee",
                    details = result.Errors
                });
            }
            return Ok(new
            {
                message = "Delivery added successfully",
                statusCode = 200
            });
        }

        [HttpGet("{governrate:alpha}")]
        public async Task<ActionResult> GetByGovernorate(string governrate)
        {
            if(governrate == null) return BadRequest();
            return Ok(await deliveryService.GetByGovernorateAsync(governrate));

        }
    }
}
