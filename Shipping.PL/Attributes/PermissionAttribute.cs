using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Shipping.DAL.Persistent.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Shipping.BL.Attributes
{
    public class PermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _permission;

        public PermissionAttribute(string permission)
        {
            this._permission = permission;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var DBContext = context.HttpContext.RequestServices.GetRequiredService<ShippingContext>();
            var userRoleID = await DBContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).ToListAsync();
            if (!userRoleID.Any())
            {
                context.Result = new ForbidResult();
                return;
            }
            var page = context.HttpContext.GetRouteData()?.Values["Controller"]?.ToString();
            var rolePermission = await DBContext.RoleClaims
                .Where(rp => userRoleID.Contains(rp.RoleId) && rp.ClaimValue == _permission)
                .ToListAsync();
            if (!rolePermission.Any())
            {
                context.Result = new ForbidResult();
                return;
            }
            foreach (var permission in rolePermission)
            {
                if (permission.ClaimValue != _permission)
                {
                    context.Result = new ForbidResult();
                    return;
                }

            }
        }
    }
}
