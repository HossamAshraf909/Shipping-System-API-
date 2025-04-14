using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.BL.DTOs.Auth.Permission;
using Shipping.BL.Services;
using Shipping.DAL.Entities.Identity;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : ControllerBase
    {
        private AuthService AuthService { get; }


        public RoleController(AuthService authService)
        {
            AuthService = authService;

        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await AuthService.GetApplicationRolesAsync());
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await AuthService.CreateRole(roleName);
            if (result)
                return Ok(new
                {
                    message = "Role Created Successfully",
                    statusCode = 200
                });


            return BadRequest("Role Creation Failed");
        }
       
        [HttpPost("AssignPermissionToRole")]
        public async Task<IActionResult> AssignPermissionToRole(AssignPermissionsToRoleDTO permissionsToRoleDTO)
        {
            var result = await AuthService.AssignPermissionToRole(permissionsToRoleDTO);
            if (result)
                return Ok("Permission Assigned Successfully");


            return BadRequest("Permission Assignment Failed");
        }
        
        [HttpGet("GetRolePermissions")]
        public async Task<IActionResult> GetRolePermissions(string role)
        {
            var result = await AuthService.GetRolePermissions(role);
           
            if (result == null)
                     return BadRequest("Role Not Found");
            
            return Ok(result);
        }
    }
}
