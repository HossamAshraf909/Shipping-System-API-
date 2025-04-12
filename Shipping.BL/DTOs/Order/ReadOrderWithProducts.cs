using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.BL.DTOs.product;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.BL.DTOs.Order
{
    public class ReadOrderWithProducts
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string branche { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public int CityId { get; set; }
        public int GovernorateId { get; set; }
        public int ShippingTypeId { get; set; }
        public int? merchantId { get; set; }
        public OrderStatus orderStatus { get; set; }
        public bool IsVillageDelivery { get; set; }
        public string VillageStreetAddress { get; set; } = null!;
        public decimal OrderPrice { get; set; }
        public double TotalWeight { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Enum for Payment Type
        public ShippingMethod ShippingMethod { get; set; } // Enum for Shipping Type
        public List<EditProductDTO> Products { get; set; } = new();
    }
}
