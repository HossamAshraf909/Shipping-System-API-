using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shipping.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Persistent.Data.Context
{
    public static class ShippingContextSeed
    {
        public static async void Initialize(IServiceProvider serviceProvider , UserManager<ApplicationUser>userManager)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ShippingContext>();

                

                // Check if the admin user already exists
                var adminUser = userManager.FindByNameAsync("admin").Result;
                if (adminUser == null)
                {
                    var admin = new ApplicationUser
                    {
                        Id = "11111111-1111-1111-1111-111111111111",
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@shipping.com",
                        NormalizedEmail = "ADMIN@SHIPPING.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "0100000000",
                        Address = "Main HQ",
                        IsDeleted = false,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = userManager.CreateAsync(admin, "Admin@123").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create admin user.");
                    }
                }
            }
        }
    }
}
