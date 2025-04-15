using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> GetAllType()
        {
            var shippingTypes= await ShippingTypeService.GetAllAsync();
            return  Ok(shippingTypes);
        }
        [HttpPost]
        public async Task<IActionResult> AddShippingType(AddShippingTypeDTO addShippingTypeDTO)
        {
            if (addShippingTypeDTO == null) BadRequest();
            if (!ModelState.IsValid)  BadRequest(ModelState);
            await ShippingTypeService.AddAsync(addShippingTypeDTO);    
            return Ok(new
            {
                message = "Shipping Type added successfully",
                statusCode = 200
            });
        }
        [HttpPut]
        public async Task<IActionResult> EditShippingType(AddShippingTypeDTO addShippingTypeDTO) 
        {
            if (!ModelState.IsValid) BadRequest();
             await ShippingTypeService.EditAsync(addShippingTypeDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteShippingType(int id)
        {
            if(!ModelState.IsValid) return BadRequest();
            await ShippingTypeService.DeleteAsync(id);
            return Ok(new
            {
                message = "Shipping Type deleted successfully",
                statusCode = 200
            });
        }
    }
}
