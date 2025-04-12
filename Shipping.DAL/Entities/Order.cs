using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public PaymentMethod PaymentType { get; set; }
    public RejectionReason RejectionReason { get; set; }
    public OrderStatus orderStatus { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    [DataType(DataType.Date)]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [DataType(DataType.Currency)]
    public decimal OrderPrice { get; set; }

    [DataType(DataType.Currency)]
    public decimal ShippingPrice { get; set; }

    public double TotalWeight { get; set; }
    public bool IsVillageDelivery { get; set; } = false;
    public string? VillageStreetAddress { get; set; } = null!;

    public int? VillageDeliveryId { get; set; }
    public virtual VillageDelivery? VillageDelivery { get; set; }


    public int CityId { get; set; }
    public virtual City City { get; set; }

    public int GovernorateId { get; set; }
    public virtual Governorate Governorate { get; set; }
    public int ShippingTypeId { get; set; }
    public virtual ShippingType ShippingType { get; set; }

    [ForeignKey("weightPrice")]
    public int WeightPriceId { get; set; }
    public virtual WeightPrice weightPrice { get; set; }
    public virtual ICollection<Order_Product> OrderProducts { get; set; } = new List<Order_Product>();

    [ForeignKey("Delivery")]
    public int? DeliveryId { get; set; }
    public virtual Delivery Delivery { get; set; }

    [ForeignKey("Merchant")]
    public int? MerchantId { get; set; }
    public virtual Merchant Merchant { get; set; }

    public int? BranchId { get; set; }
    public virtual Branches? Branche { get; set; }

}