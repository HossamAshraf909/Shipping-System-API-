using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class WeightPrice:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int DefaultWeight { get; set; }
        [DataType(DataType.Currency)]
        public decimal ExtraPricePerKilo { get; set; }

        public virtual ICollection<Order> orders { get; set; } = new List<Order>();

    }
}
