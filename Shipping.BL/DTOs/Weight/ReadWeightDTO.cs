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
        public int DefaultWeight { get; set; }
        public decimal ExtraPricePerKilo { get; set; }
    }
}
