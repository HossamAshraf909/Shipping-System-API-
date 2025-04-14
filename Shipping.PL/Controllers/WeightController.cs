using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Weight;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeightController : ControllerBase
    {
        WeightPriceService weightPriceService;
        public WeightController(WeightPriceService weightPriceService)
        {
            this.weightPriceService = weightPriceService;
        }
        [HttpGet]
         public async Task<IActionResult> GetWeightSettings()
        {
            return Ok(await weightPriceService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddWeightSetting(AddWeightDTO weight)
        {
            if (weight == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            var existingWeightSetting = await weightPriceService.GetAllAsync();
                weight.Id = existingWeightSetting[0].Id;
            if (!existingWeightSetting.Any())
                await weightPriceService.AddAsync(weight);
            else  
                await weightPriceService.UpdateAsync(weight);
            return Ok (new
            {
                message = "Weight setting added successfully",
                statusCode = 200
            });   
        }
    }
}
