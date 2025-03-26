using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.ShippingType
{
    public record ReadShippingTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
