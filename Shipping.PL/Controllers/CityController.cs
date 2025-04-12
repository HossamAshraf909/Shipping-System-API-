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
        public async Task<IActionResult> AddCity(AddCityDTO city)
        {
            if (city == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            await cityService.AddAsync(city);
            return Ok(new
            {
                message = "City added successfully",
                statusCode = 200
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await cityService.GetAllAsync();
            if (cities == null) return NotFound();
            return Ok(cities);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await cityService.GetByIdAsync(id);
            if (city == null) return NotFound();
            return Ok(city);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCity(int id, AddCityDTO city)
        {
            if (city == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await cityService.UpdateAsync(id, city);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await cityService.GetByIdAsync(id);
            if (city == null) return NotFound();
            await cityService.DeleteAsync(id);
            return Ok(new
            {
                message = "City deleted successfully",
                statusCode = 200
            });
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchword)
        {
            if (string.IsNullOrEmpty(searchword)) return BadRequest();
            var cities = await cityService.Search(searchword);
            if (cities == null) return NotFound();
            return Ok(cities);
        }
    }
}
