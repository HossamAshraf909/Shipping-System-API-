using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class ShippingType:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; } = null!;

        [DataType(DataType.Currency)]
        public decimal ShippingPrice { get; set; }
        public virtual ICollection<Order> orders { get; set; } = new List<Order>();

    }
}
