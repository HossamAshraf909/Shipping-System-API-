using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.BL.DTOs.Order
{
    public class ReadOrderDTO
    {
        public DateTime OrderDate { get; set; }
        public int Id { get; set; }
        public OrderStatus orderStatus { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;

        [DataType(DataType.Currency)]
        public decimal OrderPrice { get; set; }
        public string City { get; set; } = null!;
        public string Governorate { get; set; } = null!;
    }
}
