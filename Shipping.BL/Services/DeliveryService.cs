using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.BL.DTOs.Delivery;
using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;

namespace Shipping.BL.Services
{
    public class DeliveryService
    {
        private readonly IUnitOfWork unit;

        UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public DeliveryService(IUnitOfWork unit , UserManager<ApplicationUser> userManager , IMapper mapper)
        {
            this.unit = unit;
            this.userManager = userManager;
            this.mapper = mapper;
        }



        public async Task AddAsync (AddDeliveryDTO deliveryDTO)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = deliveryDTO.Name,
                Email = deliveryDTO.Email,
                PasswordHash = deliveryDTO.Password,
                Address = deliveryDTO.address,
            };
            await userManager.CreateAsync(applicationUser,deliveryDTO.Password);
            
            await unit.SaveChangesAsync();


            var delivery = new Delivery 
            { 
                PhoneNumber = deliveryDTO.PhoneNumber,
                TypeOfDiscount = deliveryDTO.TypeOfDiscount,
                CompanyPercent = deliveryDTO.CompanyPercent,
                governorateId=  deliveryDTO.GovernorateId,
                UserID = applicationUser.Id,
            };
            await unit.Delivery.AddAsync(delivery);
            await unit.SaveChangesAsync();
            foreach (var branchId in deliveryDTO.BranchesId)
            {
                var branch = await unit.Branches.GetByIdAsync(branchId);
                if (branch != null)
                {
                    var deliveryBranch = new DeliveryBranch
                    {
                        BranchID = branch.Id,
                        DeliveryID = delivery.ID,
                    };
                    await unit.DeliveryBranches.AddAsync(deliveryBranch);
                    await unit.SaveChangesAsync();
                }
            }
        }


       public async Task<List<ReadDeliveryDTO>> GetByGovernorateAsync (string governorate)
        {
            var deliveries = await unit.Delivery.SearchAsync(g=>g.Governorate.Name==governorate);
            var deliveriesDto = mapper.Map<List<ReadDeliveryDTO>>(deliveries);
            return deliveriesDto;
        }

    }
}
