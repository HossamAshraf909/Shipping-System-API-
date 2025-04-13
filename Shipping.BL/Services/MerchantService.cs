using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.BL.DTOs.Merchant;
using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services
{


namespace Shipping.BL.Services
    {
        public class MerchantService
        {
            private readonly IUnitOfWork unit;
            private readonly UserManager<ApplicationUser> userManager;
            private readonly RoleManager<ApplicationRole> roleManager;

            public MerchantService(IUnitOfWork unit , UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager)
            {
                this.unit = unit;
                this.userManager = userManager;
                this.roleManager = roleManager;
            }

            public async Task<bool> AddAsync(AddMerchantDTO merchantDTO)
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = merchantDTO.UserName,
                    Email = merchantDTO.Email,
                    PasswordHash = merchantDTO.Password,
                    Address = merchantDTO.Address,
                };

               var result= await userManager.CreateAsync(applicationUser,merchantDTO.Password);
                if (!result.Succeeded)
                    return false;

                if (await roleManager.RoleExistsAsync("Merchant"))
                    await userManager.AddToRoleAsync(applicationUser, "Merchant");


                var merchant = new Merchant
                {
                    PickUpPrice = merchantDTO.PickUpPrice,
                    RejectedOrderPrice = merchantDTO.RejectedOrderPrice,
                    cityId = merchantDTO.CityId,
                    governrateId = merchantDTO.GovernorateId,
                    UserID = applicationUser.Id,
                };

                await unit.Merchant.AddAsync(merchant);
                await unit.SaveChangesAsync();
                foreach (var specialPackage in merchantDTO.specialPackages)
                {
                    var package = new SpecialPackages
                    {
                        cityID = specialPackage.cityID,
                        governorateID = specialPackage.governorateID,
                        ShippingPrice = specialPackage.ShippingPrice,
                        merchantID = merchant.ID,
                    };
                    await unit.SpecialPackage.AddAsync(package);
                    await unit.SaveChangesAsync();
                }
                foreach (var branchId in merchantDTO.BranchIds)
                {
                    var branch = await unit.Branches.GetByIdAsync(branchId);
                    if (branch != null)
                    {
                        var merchantBranch = new MerchantBranch
                        {
                            BranchID = branch.Id,
                            MerchantID = merchant.ID,
                        };
                        await unit.MerchantBranches.AddAsync(merchantBranch);
                        await unit.SaveChangesAsync();
                    }
                }
                return true;
            }

            public async Task<List<Task<ReadMerchantDTO>>> GetAllAsync()
            {
                var merchants = await unit.Merchant.GetAllAsync();
               

                var result = merchants.Select(async m =>
                {
                    var user = await userManager.FindByIdAsync(m.UserID);

                    return new ReadMerchantDTO
                    {
                        CityName = m.City?.Name,
                        GovernorateName = m.Governorate?.Name,
                        PickUpPrice = m.PickUpPrice,
                        RejectedOrderPrice = m.RejectedOrderPrice,
                        UserName = user.UserName,
                        UserEmail = user?.Email
                    };
                }).ToList();

                return result;
            }
        }
    }

}

