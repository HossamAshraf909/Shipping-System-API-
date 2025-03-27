namespace Shipping.BL.DTOs.City
{
    public class AddCityDTO
    {
        public string Name { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal PickUpShippingPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int GovId { get; set; }
    }
}
