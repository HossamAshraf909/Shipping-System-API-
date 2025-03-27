using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Weight
{
    public class ReadWeightDTO
    {
        public int Id { get; set; }
        public decimal DefualPrice { get; set; }
        public decimal DefualtWeight { get; set; }
        public decimal ExtraPricePerKilo { get; set; }
    }
}
