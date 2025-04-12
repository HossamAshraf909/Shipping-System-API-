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
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashBoardController(DashboardServices dashboardServices,RoleManager<ApplicationRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            _dashboardServices = dashboardServices;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [Authorize]
        [HttpGet("order-status-counts")]
        public async Task<IActionResult> GetOrderStatusCounts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var user = await _userManager.FindByIdAsync(userId); 

            if (user == null)
                return Unauthorized(new ApiResponse<string>(
                    statusCode: 401,
                    message: "User not found",
                    data: null
                ));

          
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles == null || !userRoles.Any())
                return Unauthorized(new ApiResponse<string>(
                    statusCode: 401,
                    message: "User does not have any roles",
                    data: null
                ));

            var userRole = userRoles.First();

            var counts = await _dashboardServices.GetOrderCountsByStatus(userId, userRole);

            return Ok(counts);
        }




    }
}
