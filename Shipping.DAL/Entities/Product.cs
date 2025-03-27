using Shipping.DAL.Entities;
using System.ComponentModel.DataAnnotations;

public class Product : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(1, 100)]
    public int Quantity { get; set; }  

    [Required]
    [Range(1, 100)]
    public int Weight { get; set; }

    public virtual ICollection<Order_Product> OrderProducts { get; set; } = new List<Order_Product>(); 
}
