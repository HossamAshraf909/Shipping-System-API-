using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.Services;
using Shipping.DAL.Entities.Identity;
using System.Security.Claims;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly DashboardServices _dashboardServices;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashBoardController(DashboardServices dashboardServices,UserManager<ApplicationUser> userManager)
        {
            _dashboardServices = dashboardServices;
            _userManager = userManager;
        }




        [HttpGet("order-status-counts")]
        public async Task<IActionResult> GetOrderStatusCounts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            if (userId == null)
                return Unauthorized();

            var counts = await _dashboardServices.GetOrderCountsByStatus(userId);
            return Ok(counts);
        }



    }
}
