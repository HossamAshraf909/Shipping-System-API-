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

            public MerchantService(IUnitOfWork unit , UserManager<ApplicationUser> userManager)
            {
                this.unit = unit;
                this.userManager = userManager;
            }

            public async Task AddAsync(AddMerchantDTO merchantDTO)
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = merchantDTO.UserName,
                    Email = merchantDTO.Email,
                    PasswordHash = merchantDTO.Password,
                    Address = merchantDTO.Address,
                };

                await userManager.CreateAsync(applicationUser,merchantDTO.Password);
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

