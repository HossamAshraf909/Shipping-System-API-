using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class VillageDelivery: BaseEntity
    {
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual ICollection<Order> orders { get; set; } = new List<Order>();
    }
}
