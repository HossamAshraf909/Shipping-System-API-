using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Weight
{
    public class AddWeightDTO
    {
        public int Id { get; set; }
        public int DefualtWeight {  get; set; } //Not in SRS only Default Price na extra price per Kilo 
        public decimal ExtraPricePerKilo {  get; set; }
    }
}
