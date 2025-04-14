using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.BL.DTOs.Merchant;
using Shipping.BL.DTOs.Result;
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

            public async Task<OperationResult> AddAsync(AddMerchantDTO merchantDTO)
            {
                var resultDto = new OperationResult();
                var applicationUser = new ApplicationUser
                {
                    UserName = merchantDTO.UserName,
                    Email = merchantDTO.Email,
                    PasswordHash = merchantDTO.Password,
                    Address = merchantDTO.Address,
                    PhoneNumber = merchantDTO.PhoneNumber,
                };

               var result= await userManager.CreateAsync(applicationUser,merchantDTO.Password);
                if (!result.Succeeded)
                {
                    resultDto.Success = false;
                    resultDto.Errors.AddRange(result.Errors.Select(e => e.Description));
                    return resultDto;
                }
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
                resultDto.Success = true;
                return resultDto;
            }

            public async Task<List<ReadMerchantDTO>> GetAllAsync()
            {
                var merchants = await unit.Merchant.GetAllAsync();
                var result = new List<ReadMerchantDTO>();

                foreach (var m in merchants)
                {
                    var user = await userManager.FindByIdAsync(m.UserID);

                    result.Add(new ReadMerchantDTO
                    {
                        CityName = m.City?.Name,
                        GovernorateName = m.Governorate?.Name,
                        PickUpPrice = m.PickUpPrice,
                        RejectedOrderPrice = m.RejectedOrderPrice,
                        UserName = user?.UserName,
                        UserEmail = user?.Email,
                        ID= m.ID,
                        UserID=user?.Id,
                        UserPhoneNumber = user?.PhoneNumber,
                    });
                }

                return result;
            }
        }
    }

}

