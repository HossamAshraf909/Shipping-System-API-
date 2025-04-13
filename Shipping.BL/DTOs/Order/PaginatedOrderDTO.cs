using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Order
{
    public class PaginatedOrderDTO
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public List<ReadOrderDTO> Orders { get; set; } = new List<ReadOrderDTO>();
    }
}
