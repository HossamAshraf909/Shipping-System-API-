using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Entities.Identity;

namespace Shipping.PL.Helpers
{
    public static class PermissionSeeder
    {
        public static async void SeedRolesAndPermissions(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                // Seed roles and permissions here
                var roles = new List<string> { "Admin" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        var result = await roleManager.CreateAsync(new ApplicationRole
                        {
                            Name = role,
                            NormalizedName = role.ToUpper(),
                            CreatedDate = DateTime.Now
                        });
                        if (result.Succeeded)
                        {
                            foreach (var permission in PermissionHelper.GeneratePermissionsForAdminRole())
                            {
                                foreach (var perm in permission)
                                {
                                    var claim = new Claim("Permission", perm);
                                    // Add claim to role
                                    var _role = await roleManager.Roles.Where(roleManager => roleManager.Name == role).FirstOrDefaultAsync();
                                    await roleManager.AddClaimAsync(_role, claim);
                                }
                            }
                        }
                    }

                }
            }
        }
    }
}
