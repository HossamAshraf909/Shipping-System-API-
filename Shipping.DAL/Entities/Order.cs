using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Enums;
using System.ComponentModel.DataAnnotations;

public class Order : BaseEntity
{
    public ShippingMethod ShippingMethod { get; set; }
    public PaymentMethod PaymentType { get; set; }
    public RejectionReason RejectionReason { get; set; }

    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;

    [DataType(DataType.Currency)]
    public decimal OrderPrice { get; set; }

    [DataType(DataType.Currency)]
    public decimal ShippingPrice { get; set; }

    public double TotalWeight { get; set; }

    // Foreign Keys
    public int VillageDeliveryId { get; set; }
    public virtual VillageDelivery VillageDelivery { get; set; } = null!;

    public bool IsVillageDelivery { get; set; }  

    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;

    public int GovernorateId { get; set; }
    public virtual Governorate Governorate { get; set; } = null!;

    public int ShippingTypeId { get; set; }
    public virtual ShippingType ShippingType { get; set; } = null!;

    public virtual ICollection<Order_Product> OrderProducts { get; set; } = new List<Order_Product>(); 
}
