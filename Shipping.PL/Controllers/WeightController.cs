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

        [HttpPost]
        public async Task<IActionResult> AddWeightSetting(AddWeightDTO weight)
        {
            if (weight == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            await weightPriceService.AddAsync(weight);
            return Ok ();   
        }
    }
}
