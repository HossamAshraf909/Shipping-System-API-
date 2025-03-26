using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.ShippingType;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingTypeController : ControllerBase
    {
        public ShippingTypeService ShippingTypeService { get; }
        public ShippingTypeController(ShippingTypeService shippingTypeService)
        {
            ShippingTypeService = shippingTypeService;
        }
        [HttpGet]
        public IActionResult GetAllType()
        {
            return Ok(ShippingTypeService.GetAll());
        }
        [HttpPost]
        public IActionResult AddShippingType(AddShippingTypeDTO addShippingTypeDTO)
        {
            if (addShippingTypeDTO == null) BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ShippingTypeService.Add(addShippingTypeDTO);    
            return Ok();
        }
        [HttpPut]
        public IActionResult EditShippingType(AddShippingTypeDTO addShippingTypeDTO) 
        {
            if (!ModelState.IsValid) return BadRequest();
            ShippingTypeService.Edit(addShippingTypeDTO);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteShippingType(AddShippingTypeDTO shippingTypeDTO)
        {
            if(!ModelState.IsValid) return BadRequest();
            ShippingTypeService.Delete(shippingTypeDTO);
            return Ok();
        }
    }
}
