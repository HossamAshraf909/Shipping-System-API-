using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shipping.BL.DTOs.Auth.Permission;
using Shipping.DAL.Entities.Identity;
using Shipping.BL.Consistants;

namespace Shipping.BL.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<bool> CreateRole(string roleName)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (roleExist)
                return false;


            var role = new ApplicationRole
            {
                Name = roleName,
                CreatedDate = DateTime.Now
            };
            var result = await roleManager.CreateAsync(role);
            return result.Succeeded;
        }
        public async Task<bool> AssignPermissionTorole(AssignPermissionsToRoleDTO permissionsToRoleDTO)
        {
            var role = await roleManager.FindByIdAsync(permissionsToRoleDTO.RoleId);
            if (role == null)
            {
                return false;
            }
            var rolePermissions = await roleManager.GetClaimsAsync(role);

            if (!rolePermissions.Any())
            {
                foreach (var _permission in permissionsToRoleDTO.Permissions)
                {
                    if (_permission.canRead == true)
                    {
                        var perm = Permissions.GeneratePermission(_permission.pageName, "Create");
                        await roleManager.AddClaimAsync(role, new Claim("Permission", perm));
                    }
                    if (_permission.canUpdate == true)
                    {
                        var perm = Permissions.GeneratePermission(_permission.pageName, "Update");
                        await roleManager.AddClaimAsync(role, new Claim("Permission", perm));
                    }
                    if (_permission.canDelete == true)
                    {
                        var perm = Permissions.GeneratePermission(_permission.pageName, "Delete");
                        await roleManager.AddClaimAsync(role, new Claim("Permission", perm));
                    }
                    if (_permission.canCreate == true)
                    {
                        var perm = Permissions.GeneratePermission(_permission.pageName, "Read");
                        await roleManager.AddClaimAsync(role, new Claim("Permission", perm));
                    }

                }


            }
            return true;

        }
    }
}
