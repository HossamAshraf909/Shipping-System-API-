using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.BL.DTOs.product;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.BL.DTOs.Order
{
    public class EditOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public int CityId { get; set; }
        public int GovernorateId { get; set; }
        public int? MerchentId { get; set; }
        public int ShippingTypeId { get; set; }
        public OrderStatus orderStatus { get; set; } 
        public bool IsVillageDelivery { get; set; }
        public string? VillageStreetAddress { get; set; } = null!;
        public decimal OrderPrice { get; set; }
        public double TotalWeight { get; set; }
        public int? branchId { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Enum for Payment Type
        public ShippingMethod ShippingMethod { get; set; } // Enum for Shipping Type
        public List<EditProductDTO> Products { get; set; } = new();
    }
}
