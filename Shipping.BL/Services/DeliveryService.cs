using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.BL.DTOs.Delivery;
using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;

namespace Shipping.BL.Services
{
    public class DeliveryService
    {
        private readonly IUnitOfWork unit;

        public DeliveryService(IUnitOfWork unit)
        {
            this.unit = unit;
            
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
            var delivery = new Delivery 
            { 
                Branch = deliveryDTO.Branch,
                Governorate = deliveryDTO.Governorate,
                PhoneNumber = deliveryDTO.PhoneNumber,
                TypeOfDiscount = deliveryDTO.TypeOfDiscount,
                CompanyPercent = deliveryDTO.CompanyPercent,
                UserID = applicationUser.Id,
            };

            await unit.ApplicationUser.AddAsync(applicationUser);
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
