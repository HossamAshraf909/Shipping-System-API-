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

            public MerchantService(IUnitOfWork unit)
            {
                this.unit = unit;
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

                var merchant = new Merchant
                {
                    PickUpPrice = merchantDTO.PickUpPrice,
                    RejectedOrderPrice = merchantDTO.RejectedOrderPrice,
                    //cityId = merchantDTO.CityId,
                    //governrateId = merchantDTO.GovernorateId,
                    UserID = applicationUser.Id,
                };

                await unit.ApplicationUser.AddAsync(applicationUser);
                await unit.Merchant.AddAsync(merchant);
                await unit.SaveChangesAsync();
            }

            public async Task<List<ReadMerchantDTO>> GetAllAsync()
            {
                var merchants = await unit.Merchant.GetAllAsync();
                var users = await unit.ApplicationUser.GetAllAsync();

                var result = merchants.Select(m =>
                {
                    var user = users.FirstOrDefault(u => u.Id == m.UserID);

                    return new ReadMerchantDTO
                    {
                        CityName = m.City?.Name,
                        GovernorateName = m.Governorate?.Name,
                        PickUpPrice = m.PickUpPrice,
                        RejectedOrderPrice = m.RejectedOrderPrice,
                        UserName = user?.UserName,
                        UserEmail = user?.Email
                    };
                }).ToList();

                return result;
            }
        }
    }

}

