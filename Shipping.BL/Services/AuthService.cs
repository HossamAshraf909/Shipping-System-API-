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
using Shipping.DAL.Consistants;
using Microsoft.EntityFrameworkCore;
using Shipping.BL.DTOs.Auth.Role;
using AutoMapper;

namespace Shipping.BL.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IMapper mapper;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        public async Task<List<ReadRoleDTO>> GetApplicationRolesAsync()
        {
            
            var Roles = mapper.Map<List<ReadRoleDTO>>(await roleManager.Roles.ToListAsync());
            return Roles;
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
        public async Task<bool> AssignPermissionToRole(AssignPermissionsToRoleDTO permissionsToRoleDTO)
        {
            var role = await roleManager.FindByIdAsync(permissionsToRoleDTO.RoleId);
            if (role == null)
            {
                return false;
            }
            var rolePermissions = await roleManager.GetClaimsAsync(role);
            foreach(var claim in rolePermissions)
                    await roleManager.RemoveClaimAsync(role,claim);
            
            if (!rolePermissions.Any())
            {
                foreach (var _permission in permissionsToRoleDTO.Permissions)
                {
                    if (_permission.canRead == true)
                    {
                        var perm = Permissions.GeneratePermission(_permission.pageName, "Read");
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
                        var perm = Permissions.GeneratePermission(_permission.pageName, "Create");
                        await roleManager.AddClaimAsync(role, new Claim("Permission", perm));
                    }

                }


            }
            return true;

        }
        public async Task<List<PermissionDTO>> GetRolePermissions(string role)
        {
            var Role = await roleManager.FindByNameAsync(role);
            var rolePermissions = await roleManager.GetClaimsAsync(Role);

            var permissionDTOMap = new Dictionary<string, PermissionDTO>();

            if (!rolePermissions.Any())
                return new List<PermissionDTO>();

            foreach (var rolePermission in rolePermissions)
            {
                var parts = rolePermission.Value.Split('.');
                if (parts.Length != 3) continue;

                var pageName = parts[1];
                var permissionType = parts[2];

                if (!permissionDTOMap.TryGetValue(pageName.ToLower(), out var dto))
                {
                    dto = new PermissionDTO
                    {
                        pageName = pageName,
                        canCreate = false,
                        canRead = false,
                        canUpdate = false,
                        canDelete = false
                    };
                    permissionDTOMap[pageName.ToLower()] = dto;
                }

                switch (permissionType)
                {
                    case "Create":
                        dto.canCreate = true;
                        break;
                    case "Read":
                        dto.canRead = true;
                        break;
                    case "Update":
                        dto.canUpdate = true;
                        break;
                    case "Delete":
                        dto.canDelete = true;
                        break;
                }
            }

            return permissionDTOMap.Values.ToList();

        }
    }
} 
