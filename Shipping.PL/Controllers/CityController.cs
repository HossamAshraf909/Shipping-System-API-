using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.City;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        CityService cityService;
        public CityController(CityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpPost]
        public IActionResult AddCity(AddCityDTO city)
        {
            if (city == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            cityService.Add(city);
            return Ok();
        }

    }
}
