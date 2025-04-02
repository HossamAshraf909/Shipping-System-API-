using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.product
{
    public record ReadProductDTO
    {
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int Weight { get; set; }
    }
}
