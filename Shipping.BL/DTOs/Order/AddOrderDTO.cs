using Shipping.BL.DTOs.OrderProduct;

namespace Shipping.BL.DTOs.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;

        public int CityId { get; set; }
        public int GovernorateId { get; set; }
        public int ShippingTypeId { get; set; }

        public bool IsVillageDelivery { get; set; }
        public string VillageStreetAddress { get; set; } = null!;

        public decimal OrderPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public double TotalWeight { get; set; }

        public int PaymentMethod { get; set; } // Enum for Payment Type
        public int ShippingMethod { get; set; } // Enum for Shipping Type

        public List<OrderProductDTO> OrderProducts { get; set; } = new List<OrderProductDTO>();
    }


}
