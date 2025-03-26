namespace Shipping.BL.DTOs.City
{
    public class ReadCityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal PickUpShippingPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int GovId { get; set; }
    }
}
