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
        public RoleManager<ApplicationRole> RoleManager { get; }

        public RoleController(AuthService authService , RoleManager<ApplicationRole> roleManager)
        {
            AuthService = authService;
            RoleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var Roles = await RoleManager.Roles.Select(r => new { r.Name, r.CreatedDate }).ToListAsync();
            return Ok(Roles);
        
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await AuthService.CreateRole(roleName);
            if (result)
                return Ok("Role Created Successfully");


            return BadRequest("Role Creation Failed");
        }
        [HttpPost("AssignPermissionToRole")]
        public async Task<IActionResult> AssignPermissionToRole(AssignPermissionsToRoleDTO permissionsToRoleDTO)
        {
            var result = await AuthService.AssignPermissionTorole(permissionsToRoleDTO);
            if (result)
                return Ok("Permission Assigned Successfully");


            return BadRequest("Permission Assignment Failed");
        }
    }
}
