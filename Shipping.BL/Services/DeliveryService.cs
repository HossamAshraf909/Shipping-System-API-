using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public DeliveryService(IUnitOfWork unit , UserManager<ApplicationUser> userManager)
        {
            this.unit = unit;
            this.userManager = userManager;
            
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

            var user = await userManager.FindByNameAsync(deliveryDTO.Name);

            var delivery = new Delivery 
            { 
                Branch = deliveryDTO.Branch,
                Governorate = deliveryDTO.Governorate,
                PhoneNumber = deliveryDTO.PhoneNumber,
                TypeOfDiscount = deliveryDTO.TypeOfDiscount,
                CompanyPercent = deliveryDTO.CompanyPercent,
                UserID = user.Id,
            };

           
            await unit.Delivery.AddAsync(delivery);

        }


       public async Task<List<string>> GetByGovernorateAsync (string governorate)
        {
         
            var deliveries = await unit.Delivery.GetAllAsync();
            var deliveriesNames = deliveries.Where(x=>x.Governorate == governorate)
                                            .Select(s=>s.User.UserName).ToList();

            return deliveriesNames;

        }





    }
}
