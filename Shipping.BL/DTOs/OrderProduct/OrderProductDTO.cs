using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.OrderProduct
{
    public class ReadOrderProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public double Weight { get; set; } 
    }

}
