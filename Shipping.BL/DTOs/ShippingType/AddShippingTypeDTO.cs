using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.ShippingType
{
    public class AddShippingTypeDTO
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public string Type { get; set; } = null!;

        [DataType(DataType.Currency)]
        public decimal ShippingPrice { get; set; }
    }
}
