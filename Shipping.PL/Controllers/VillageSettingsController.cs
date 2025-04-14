using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Village;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VillageSettingsController : ControllerBase
    {
        private VillageDeliveryService DeliveryService { get; }
        public VillageSettingsController(VillageDeliveryService DeliveryService)
        {
            this.DeliveryService = DeliveryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVillages()
        {
            var VillageSetting = await DeliveryService.GetAllAsync();
            return Ok(VillageSetting);
        }
        [HttpPost]
        public async Task<IActionResult> AddVillageSetting(AddVillageDTO addVillageDTO)
        {
            var existingVillageSetting = await DeliveryService.GetAllAsync();
            addVillageDTO.Id = existingVillageSetting[0].Id;
            if (!existingVillageSetting.Any())
             await DeliveryService.AddAsync(addVillageDTO);
            else
            await DeliveryService.UpdateAsync(existingVillageSetting[0].Id, addVillageDTO);

            return Ok(new
            {
                message = "Village Setting added successfully",
                statusCode = 200
            });
        }
    }
}
