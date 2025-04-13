
﻿using Shipping.BL.DTOs.OrderProduct;
using Shipping.DAL.Persistent.Enums;
using Shipping.DAL.Entities;
using Shipping.BL.DTOs.product;
namespace Shipping.BL.DTOs.Order
{
    public class AddOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public int CityId { get; set; }
        public int GovernorateId { get; set; }
        public int MerchentId { get; set; }
        public int ShippingTypeId { get; set; }
        public OrderStatus orderStatus { get; set; } = OrderStatus.New;
        public bool IsVillageDelivery { get; set; }
        public string VillageStreetAddress { get; set; } = null!;
        public decimal OrderPrice { get; set; }
        public double TotalWeight { get; set; }
<<<<<<< HEAD
        public int branchId { get; set; }
=======
        public string Branche { get; set; }
>>>>>>> e460d89be5ad973dedd31e3b79ee350288fe4afa
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; } // Enum for Payment Type
        public ShippingMethod ShippingMethod { get; set; } // Enum for Shipping Type
        public List<CreateProductDTO> Products { get; set; } = new();
    }

}



