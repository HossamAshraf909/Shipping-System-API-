using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Order_Product
    {
        public int ProdID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("ProdID")]
        public virtual Product product { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order order { get; set; }
    }
}
