using Microsoft.AspNetCore.Http;
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
            await deliveryService.AddAsync(delivery);
            return Ok();
        }



        [HttpGet]
        public async Task<ActionResult> GetByGovernorate(string Governorate)
        {
            if(Governorate == null) return BadRequest();
            return Ok(await deliveryService.GetByGovernorateAsync(Governorate));

        }
    }
}
