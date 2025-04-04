using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.BL.DTOs.OrderReport
{
    public class ReadOrderReportDTO
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string city { get; set; } = null!;
        public string Governorate { get; set; } = null!;
        public decimal OrderPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal PaidShippingPrice { get; set; }
        public DateTime OrderDate {  get; set; }
        
    }
}
