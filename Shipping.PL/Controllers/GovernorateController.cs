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
        public IActionResult GetAllGovernorates()
        {
            return Ok(governorateService.GetAll());
        }



        [HttpGet]
        [Route("api/governorateSearch/{searchWord}")]
        public IActionResult SearchForGovernorate(string searchWord)
        {
            return Ok(governorateService.Search(searchWord));
        }



        [HttpPost]
        public IActionResult AddGovernorate(AddGovernorateDTO governorate)
        {
            if (governorate == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            governorateService.Add(governorate);
            return Ok();
        }



        [HttpPut]
        public IActionResult UpdateGovernorate(AddGovernorateDTO governorate)
        {
            if(governorate == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest();    
            governorateService.Update(governorate);
            return Ok();
        }

        //Entities
    }
}
