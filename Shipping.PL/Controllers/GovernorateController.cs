using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Governorate;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        GovernorateService governorateService;
        public GovernorateController(GovernorateService governorateService)
        {
            this.governorateService = governorateService;
            
        }



        [HttpGet]
        public async Task<IActionResult> GetAllGovernorates()
        {
            return Ok(await governorateService.GetAllAsync());
        }



        [HttpGet("/governorateSearch/{searchWord:alpha}")]
        public async Task<IActionResult> SearchForGovernorate(string searchWord)
        {
            return Ok(await governorateService.SearchAsync(searchWord));
        }



        [HttpPost]
        public async Task< IActionResult> AddGovernorate(AddGovernorateDTO governorate)
        {
            if (governorate == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await governorateService.AddAsync(governorate);
            return Ok(new
            {
                message = "Governorate added successfully",
                statusCode = 200
            });
        }



        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGovernorate(int id,AddGovernorateDTO governorate)
        {
            if(governorate == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest();    
           await governorateService.UpdateAsync(id,governorate);
            return Ok(new
            {
                message = "Governorate updated successfully",
                statusCode = 200
            });
        }

        //Entities
    }
}
